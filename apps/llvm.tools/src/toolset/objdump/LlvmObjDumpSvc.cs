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

        WsProjects Projects => Service(Wf.WsProjects);

        ApiCodeBanks CodeBanks => Service(Wf.ApiCodeBanks);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

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
               var items = Projects.ParseCmdResponse(response);
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
                result = AsmParser.encid(data[j++].Text, out dst.Id);
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

        public ObjDumpBlocks Collect(CollectionContext context)
        {
            var rows = Consolidate(context);
            var blocks = CalcObjBlocks(rows);
            TableEmit(blocks.View, ObjBlock.RenderWidths, Projects.ObjBlockPath(context.Project));
            Projects.RecodedSrcDir(context.Project).Clear();
            EmitAsmCodeBlocks(context,RecodeBlocks);
            return new ObjDumpBlocks(blocks,rows);
        }

        void RecodeBlocks(in IProjectWs project, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";

            var srcdir = Projects.RecodedSrcDir(project);
            var srcpath = srcdir + FS.file(src.Origin.Format().Remove(string.Format(".{0}", FileKind.ObjAsm.Ext().Format())), FileKind.Asm.Ext());
            var emitting = EmittingFile(srcpath);
            var counter = 0u;
            using var writer = srcpath.AsciWriter();
            writer.WriteLine(intel_syntax);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var label = asm.label(block.Label.Name.Format());
                writer.WriteLine();
                writer.WriteLine(label.Format());
                counter++;
                var count = block.Count;
                for(var j=0; j<count; j++)
                {
                    ref readonly var asmcode = ref block[j];
                    writer.WriteLine(string.Format("    {0,-48} # {1}", asmcode.Asm, asmcode.Encoding.FormatHex(Chars.Space, false)));
                }
            }

            EmittedFile(emitting,counter);
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

        void EmitAsmCodeBlocks(CollectionContext context, Receiver<IProjectWs,AsmCodeBlocks> emitted)
        {
            var project = context.Project;
            Projects.AsmCodeDir(project).Clear();

            var files = context.Files.Entries(FileKind.ObjAsm);
            var count = files.Count;
            using var alloc = Alloc.allocate();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var result = ParseDumpSource(file, out var records);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var blocks = AsmObjects.DistillBlocks(file, records, alloc);
                var dst = Projects.AsmCodePath(project, file.Path.FileName.Format());
                AsmObjects.Emit(blocks,dst);
                emitted(project,blocks);
            }
        }

        Index<ObjDumpRow> Consolidate(CollectionContext context)
        {
            var project = context.Project;
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
                var fref = context.FileRef(path);
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
                    context.EventReceiver.Collected(fref, record);
                }
                total += docseq;
            }
            EmittedTable(flow, total);
            return emitted.ToArray();
        }
    }
}