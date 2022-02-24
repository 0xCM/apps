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

        public Index<ObjDumpRow> LoadRows(IProjectWs project)
            => LoadRows(Projects.Table<ObjDumpRow>(project));

        Index<ObjDumpRow> LoadRows(FS.FilePath src)
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
                result = AsmParser.encid(data[j++].Text, out dst.EncodingId);
                result = DataParser.parse(data[j++], out dst.OriginId);
                result = AsmParser.instid(data[j++].Text, out dst.InstructionId);
                result = DataParser.parse(data[j++], out dst.DocSeq);
                result = DataParser.parse(data[j++], out dst.Section);
                result = DataParser.parse(data[j++], out dst.BlockAddress);
                result = DataParser.parse(data[j++], out dst.BlockName);
                result = DataParser.parse(data[j++], out dst.IP);
                result = DataParser.parse(data[j++], out dst.Size);
                result = AsmParser.asmhex(data[j++].View, out dst.Encoded);
                dst.Asm = text.trim(data[j++].Text);
                result = AsmParser.comment(data[j++].View, out dst.Comment);
                result = DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }

        public Outcome ParseDumpSource(WsContext context, in FileRef src, out Index<ObjDumpRow> dst)
            => new LlvmObjDumpParser().ParseSource(context, src, out dst);

        public ObjDumpBlocks Collect(WsContext context)
        {
            var rows = Consolidate(context);
            var blocks = CalcObjBlocks(rows);
            TableEmit(blocks.View, ObjBlock.RenderWidths, Projects.ObjBlockPath(context.Project));
            context.Receiver.Collected(blocks);

            Projects.RecodedSrcDir(context.Project).Clear();
            EmitAsmCodeBlocks(context, RecodeBlocks);
            return new ObjDumpBlocks(blocks,rows);
        }

        void RecodeBlocks(in IProjectWs project, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var asmdir = Projects.RecodedSrcDir(project);
            var asmpath = asmdir + FS.file(src.OriginName.Format().Remove(string.Format(".{0}", FileKind.ObjAsm.Ext().Format())), FileKind.Asm.Ext());
            var emitting = EmittingFile(asmpath);
            var counter = 0u;
            using var writer = asmpath.AsciWriter();
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

        public Index<ObjBlock> LoadObjBlocks(IProjectWs project)
        {
            var path = Projects.ObjBlockPath(project);
            var lines = path.ReadLines(true);
            var reader = lines.Reader();
            reader.Next();
            var buffer = alloc<ObjBlock>(lines.Length - 1);
            var i=0u;
            while(reader.Next(out var line))
            {
                var cells = text.split(line,Chars.Pipe);
                Require.equal(ObjBlock.FieldCount, cells.Length);
                ref var dst = ref seek(buffer,i++);
                var src = cells.Reader();
                DataParser.parse(src.Next(), out dst.OriginId).Require();
                DataParser.parse(src.Next(), out dst.BlockName).Require();
                DataParser.parse(src.Next(), out dst.BlockNumber).Require();
                DataParser.parse(src.Next(), out dst.BlockBase).Require();
                DataParser.parse(src.Next(), out dst.BlockSize).Require();
                DataParser.parse(src.Next(), out dst.Source).Require();
            }
            return buffer;
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
                    docid = row.OriginId;
                    blockname = row.BlockName;
                    source = row.Source;
                    docname = row.Source.Path.FileName.Format();
                    @base = row.BlockAddress;
                }

                if(row.BlockName != blockname)
                {
                    var block = new ObjBlock();
                    block.OriginId = docid;
                    block.BlockBase = @base;
                    block.BlockName = blockname;
                    block.BlockNumber = number++;
                    block.BlockSize = size;
                    block.Source = source;
                    dst.Add(block);
                    size = 0;
                    source = row.Source;
                }

                if(row.OriginId != docid)
                    number = 0;

                docid = row.OriginId;
                blockname = row.BlockName;
                docname = row.Source.Path.FileName.Format();
                @base = row.BlockAddress;
                size += row.Size;

                if(i==count-1)
                {
                    var block = new ObjBlock();
                    block.OriginId = docid;
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

        void EmitAsmCodeBlocks(WsContext context, Receiver<IProjectWs,AsmCodeBlocks> emitted)
        {
            var project = context.Project;
            Projects.AsmCodeDir(project).Clear();

            var files = context.Files.Entries(FileKind.ObjAsm);
            var count = files.Count;
            using var alloc = Alloc.allocate();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var result = ParseDumpSource(context, file, out var records);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var blocks = AsmObjects.DistillBlocks(context, file, records, alloc);
                AsmObjects.Emit(context, blocks, Projects.AsmCodePath(project, file.Path.FileName.Format()));
                emitted(project,blocks);
            }
        }

        Index<ObjDumpRow> Consolidate(WsContext context)
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
                result = ParseDumpSource(context, fref, out var records);
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
                }
                total += docseq;
            }

            EmittedTable(flow, total);

            var data = emitted.ToArray();
            context.Receiver.Collected(data);
            return data;
        }
    }
}