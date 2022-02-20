//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static core;

    [Tool(ToolId)]
    public sealed class LlvmObjDumpSvc : ToolService<LlvmObjDumpSvc>
    {
        public const string ToolId = ToolNames.llvm_objdump;

        WsProjects WsProjects => Service(Wf.WsProjects);

        ApiCodeBanks CodeBanks => Service(Wf.ApiCodeBanks);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

        FS.FolderPath AsmCodeDir(IProjectWs project)
            => ProjectDb.ProjectData() + FS.folder(string.Format("{0}.asm.code", project.Name.Format()));

        FS.FilePath AsmCodePath(IProjectWs project, string origin)
            => AsmCodeDir(project) + FS.file(string.Format("{0}.code", origin), FS.Csv);

        FS.FilePath ObjBlockPath(IProjectWs project)
            => ProjectDb.ProjectTable<ObjBlock>(project);


        public LlvmObjDumpSvc()
            : base(ToolId)
        {

        }

        public Outcome Run(FS.FilePath src, FS.FolderPath dst)
        {
            var tool = ToolNames.llvm_objdump;
            var cmd = Cmd.cmdline(Ws.Tools().Script(tool, "run").Format(PathSeparator.BS));
            var vars = WsVars.create();
            vars.DstDir = dst;
            vars.SrcDir = src.FolderPath;
            vars.SrcFile = src.FileName;
            var result = OmniScript.Run(cmd, vars.ToCmdVars(), out var response);
            if(result)
            {
               var items = WsProjects.ParseCmdResponse(response);
               iter(items, item => Write(item));
            }
            return result;
        }

        public Index<ObjDumpRow> LoadRows(FS.FilePath src)
        {
            var result = TextGrids.load(src, TextEncodingKind.Asci, out var grid);
            if(result.Fail)
            {
                Error(result.Message);
                return sys.empty<ObjDumpRow>();
            }

            var count = grid.RowCount;
            var buffer = alloc<ObjDumpRow>(count);
            ref var target = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var data = ref grid[(int)i];
                ref var dst = ref seek(target,i);
                var j=0;
                result = DataParser.parse(data[j++], out dst.Seq);
                result = DataParser.parse(data[j++], out dst.Id);
                result = DataParser.parse(data[j++], out dst.DocId);
                result = DataParser.parse(data[j++], out dst.DocSeq);
                result = DataParser.parse(data[j++], out dst.Section);
                result = DataParser.parse(data[j++], out dst.BlockAddress);
                result = DataParser.parse(data[j++], out dst.BlockName);
                result = DataParser.parse(data[j++], out dst.IP);
                result = DataParser.parse(data[j++], out dst.Size);
                result = AsmParser.asmhex(data[j++].View, out dst.HexCode);
                dst.Asm = text.trim(data[j++].Text);
                result = AsmParser.comment(data[j++].View, out dst.Comment);
                result = DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }

        public Outcome ParseDumpSource(in FileRef src, out Index<ObjDumpRow> dst)
            => new LlvmObjDumpParser().ParseSource(src, out dst);

        public Outcome DumpObjects(ReadOnlySpan<FS.FilePath> src, FS.FolderPath outdir, Action<CmdResponse> handler)
        {
            var count = src.Length;
            var tool = ToolNames.llvm_objdump;
            var cmd = Cmd.cmdline(Ws.Tools().Script(tool, "run").Format(PathSeparator.BS));
            var result = Outcome.Success;
            var responses = list<CmdResponse>();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var vars = WsVars.create();
                vars.DstDir = outdir;
                vars.SrcDir = path.FolderPath;
                vars.SrcFile = path.FileName;
                result = OmniScript.Run(cmd, vars.ToCmdVars(), out var lines);
                if(result.Fail)
                    break;

                var len = lines.Length;
                for(var j=0; j<len; j++)
                {
                    if(CmdResponse.parse(skip(lines,j).Content, out var response))
                        handler(response);
                }
            }
            return result;
        }

        public void Collect(CollectionContext collect)
        {
            var rows = Consolidate(collect);
            var blocks = CalcObjBlocks(rows);
            TableEmit(blocks.View, ObjBlock.RenderWidths, ObjBlockPath(collect.Project));
            EmitCodeBlocks(collect);
            Recode(collect,rows);
            EmitIndex(collect,rows);
        }


        Index<ObjBlock> CalcObjBlocks(Index<ObjDumpRow> src)
        {
            src.Sort();
            var count = src.Count;
            var docid = 0u;
            var docname = EmptyString;
            var blockname = EmptyString;
            var @base = MemoryAddress.Zero;
            var dst = list<ObjBlock>();
            var size = 0u;
            var number = 0u;
            var source = FS.FileUri.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];
                if(i==0)
                {
                    docid = row.DocId;
                    blockname = row.BlockName;
                    source = row.Source;
                    docname = row.Source.Path.FileName.Format();
                    @base = row.BlockAddress;
                }

                if(row.BlockName != blockname)
                {
                    var block = new ObjBlock();
                    block.DocId = docid;
                    block.BlockBase = @base;
                    block.BlockName = blockname;
                    block.BlockNumber = number++;
                    block.BlockSize = size;
                    block.Source = source;
                    dst.Add(block);
                    size = 0;
                    source = row.Source;
                }

                if(row.DocId != docid)
                    number = 0;

                docid = row.DocId;
                blockname = row.BlockName;
                docname = row.Source.Path.FileName.Format();
                @base = row.BlockAddress;
                size += row.Size;

                if(i==count-1)
                {
                    var block = new ObjBlock();
                    block.DocId = docid;
                    block.BlockName = blockname;
                    block.BlockBase = @base;
                    block.BlockNumber = number++;
                    block.Source = source;
                    block.BlockSize = size;
                    dst.Add(block);
                }
            }
            return dst.ToArray();
        }

        void EmitCodeBlocks(CollectionContext collect)
        {
            var project = collect.Project;
            AsmCodeDir(project).Clear();

            var files = collect.Files.Entries(FileKind.ObjAsm);
            var count = files.Count;

            using var dispenser = Alloc.dispensers();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var result = ParseDumpSource(file, out var records);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var blocks = AsmObjects.DistillBlocks(file, records, dispenser);
                var dst = AsmCodePath(project, file.Path.FileName.Format());
                AsmObjects.Emit(blocks,dst);
            }
        }

        void EmitCodeBlocks(CollectionContext collect, Index<ObjDumpRow> src)
        {
            var project = collect.Project;
            using var dispenser = Alloc.dispensers();
            var blocks = AsmObjects.DistillBlocks(project, src, dispenser);
            AsmObjects.Emit(blocks, AsmCodeDir(project).Clear());
        }

        Index<ObjDumpRow> Consolidate(CollectionContext collect)
        {
            var project = collect.Project;
            var src = project.OutFiles(FileKind.ObjAsm).View;
            var dst = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjDumpRow>(ObjDumpRow.RenderWidths);
            var flow = EmittingTable<ObjDumpRow>(dst);
            var emitted = list<ObjDumpRow>();
            var total=0u;
            var seq = 0u;
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var fref = collect.FileRef(path);
                result = ParseDumpSource(fref, out var records);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }

                var docseq = 0u;
                for(var j=0; j<records.Length; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    record.Seq = seq++;
                    writer.WriteLine(formatter.Format(record));
                    emitted.Add(record);
                    collect.EventReceiver.Collected(fref, record);
                }
                total += docseq;
            }
            EmittedTable(flow, total);
            return emitted.ToArray();
        }

        void EmitIndex(CollectionContext collect, ReadOnlySpan<ObjDumpRow> rows)
        {
            var count = rows.Length;
            var buffer = alloc<AsmCodeIndexRow>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var code = ref skip(rows,i);
                ref readonly var row = ref rows[i];
                if(code.HexCode != row.HexCode)
                {
                    Error("Hex mismatch");
                }

                dst.Seq = row.Seq;
                dst.DocId = row.DocId;
                dst.DocSeq = row.DocSeq;
                dst.Id = row.Id;
                dst.IP = (Address32)code.IP;
                dst.Encoding = code.HexCode;
                dst.Size = code.Size;
                dst.Asm = code.Source.Format();
            }

            buffer.Sort();

            var path = ProjectDb.ProjectTable<AsmCodeIndexRow>(collect.Project);
            TableEmit(@readonly(buffer), AsmCodeIndexRow.RenderWidths, path);
            collect.EventReceiver.Emitted(buffer,path);
        }

        Outcome Recode(CollectionContext collection, ReadOnlySpan<ObjDumpRow> rows)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var project = Ws.Project(ProjectNames.McRecoded);
            var count = rows.Length;
            var srcid = EmptyString;
            var block = EmptyString;
            var dstdir = project.SrcDir(collection.Project.Project.Format());
            dstdir.Clear();
            var dstpath = FS.FilePath.Empty;
            var emitting = default(WfFileWritten);
            var lines = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                var path = (FS.FilePath)row.Source;
                var _srcid = path.SrcId(FileKind.ObjAsm);

                if(empty(srcid))
                {
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, FileKind.Asm.Ext());
                    lines.Add(intel_syntax);
                    emitting = EmittingFile(dstpath);
                }
                else if(srcid != _srcid)
                {
                    if(lines.Count != 0)
                    {
                        using var writer = dstpath.AsciWriter();
                        iter(lines, line => writer.WriteLine(line));
                        EmittedFile(emitting, lines.Count);
                    }

                    lines.Clear();
                    lines.Add(intel_syntax);
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, FileKind.Asm.Ext());
                    EmittingFile(dstpath);
                }

                if(empty(block) || block != row.BlockName)
                {
                    if(nonempty(block))
                        lines.Add(EmptyString);

                    block = row.BlockName;
                    lines.Add(new AsmBlockLabel(block).Format());
                    continue;
                }

                if(row.Asm.IsNonEmpty)
                    lines.Add(string.Format("    {0}", row.Asm));
            }

            if(lines.Count != 0)
            {
                using var writer = dstpath.AsciWriter();
                iter(lines, line => writer.WriteLine(line));
                EmittedFile(emitting, lines.Count);
            }
            return true;
        }
    }
}