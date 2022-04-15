//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectDataServices
    {
        public ObjDumpBlocks CollectObjDump(WsContext context)
        {
            var rows = ConsolidateObjDumpRows(context);
            var blocks = CalcObjBlocks(rows);
            TableEmit(blocks.View, ObjBlock.RenderWidths, Projects.ObjBlockPath(context.Project));
            using var alloc = Alloc.allocate();
            var asmblocks = EmitAsmCodeBlocks(context, alloc);
            Projects.RecodedSrcDir(context.Project).Clear();
            for(var i=0; i<asmblocks.Count; i++)
            {
                ref readonly var block = ref asmblocks[i];
                RecodeBlocks(context.Project, block);
            }
            return new ObjDumpBlocks(blocks,rows);
        }

       public Index<ObjDumpRow> LoadObjDumpRows(IProjectWs project)
            => LoadObjDumpRows(Projects.Table<ObjDumpRow>(project));

        Index<ObjDumpRow> LoadObjDumpRows(FS.FilePath src)
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
                result = DataParser.parse(data[j++], out dst.DocSeq);
                result = DataParser.parse(data[j++], out dst.OriginId);
                result = AsmParser.encid(data[j++].Text, out dst.EncodingId);
                result = AsmParser.instid(data[j++].Text, out dst.InstructionId);
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

        public Outcome ParseObjDumpSource(WsContext context, in FileRef src, out Index<ObjDumpRow> dst)
            => new ObjDumpParser().ParseSource(context, src, out dst);

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
                DataParser.parse(src.Next(), out dst.Seq).Require();
                DataParser.parse(src.Next(), out dst.BlockNumber).Require();
                DataParser.parse(src.Next(), out dst.OriginId).Require();
                DataParser.parse(src.Next(), out dst.BlockName).Require();
                DataParser.parse(src.Next(), out dst.BlockAddress).Require();
                DataParser.parse(src.Next(), out dst.BlockSize).Require();
                DataParser.parse(src.Next(), out dst.Source).Require();
            }
            return buffer;
        }

        Index<AsmCodeBlocks> EmitAsmCodeBlocks(WsContext context, Alloc alloc)
        {
            Projects.AsmCodeDir(context.Project).Clear();
            var files = context.Catalog.Entries(FileKind.ObjAsm);
            var count = files.Count;
            var seq = 0u;
            var dst = list<AsmCodeBlocks>();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var result = ParseObjDumpSource(context, file, out var records);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var blocks = AsmObjects.DistillBlocks(context, file, ref seq, records, alloc);
                dst.Add(blocks);
                EmitAsmCodeBlocks(context, blocks, Projects.AsmCodePath(context.Project, file.Path.FileName.Format()));
            }
            return dst.ToArray();
        }

        public void EmitAsmCodeBlocks(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
        {
            var buffer = alloc<AsmCodeRow>(src.LineCount);
            var k=0u;
            var distinct = hashset<Hex64>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var count = block.Count;
                for(var j=0; j<count; j++, k++)
                {
                    ref readonly var code = ref block[j];
                    ref var record = ref seek(buffer,k);
                    record.Seq = k;
                    record.DocSeq = code.DocSeq;
                    record.EncodingId = code.EncodingId;
                    record.OriginId = code.OriginId;
                    record.InstructionId = AsmBytes.instid(code.OriginId, code.IP, code.Encoding);
                    record.OriginName = src.OriginName;
                    record.BlockBase = block.Label.Location;
                    record.BlockName = block.Label.Name;
                    record.IP = code.IP;
                    record.Size = code.Encoded.Size;
                    record.Encoded = code.Encoded;
                    record.Asm = code.Asm;

                    if(!distinct.Add(record.EncodingId))
                        Warn(string.Format("Duplicate identifier:{0}", record.EncodingId));
                }
            }

            TableEmit(@readonly(buffer), AsmCodeRow.RenderWidths, dst);
        }

        Index<ObjDumpRow> ConsolidateObjDumpRows(WsContext context)
        {
            var project = context.Project;
            var src = project.OutFiles(FileKind.ObjAsm).Storage.Sort();
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjDumpRow>(ObjDumpRow.RenderWidths);
            var buffer = bag<ObjDumpRow>();

            iter(src, path => {
                result = ParseObjDumpSource(context, context.Ref(path), out var records);
                if(result.Fail)
                {
                    Error(result.Message);
                    return;
                }

                var docseq = 0u;
                for(var j=0; j<records.Length; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    buffer.Add(record);
                }
            }, true);

            var data = buffer.ToArray().Sort();
            for(var i=0u; i<data.Length; i++)
                seek(data,i).Seq = i;

            TableEmit(@readonly(data), ObjDumpRow.RenderWidths, TextEncodingKind.Asci, Projects.Table<ObjDumpRow>(project));
            return data;
        }
    }
}