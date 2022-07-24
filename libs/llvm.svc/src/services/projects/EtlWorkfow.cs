//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectSvc
    {
        public void Etl(IWsProject project)
        {
            var context = WsContext.load(project);
            Etl(context);
            // AsmObjects.CollectObjects(context);
            // AsmObjects.Emit(context, AsmObjects.CalcObjSyms(context));
            // AsmObjects.CollectCoffData(context);
            // CollectAsmSyntax(context);
            // CollectMcInstructions(context);
            // XedDisasm.Collect(context);
        }

        IDbTargets EtlTargets(ProjectId project)
            => AppDb.EtlTargets(project);

        void Etl(WsContext context)
        {
            var project = context.Project.Id;
            EtlTargets(project).Delete();
            TableEmit(context.Catalog.Entries(), AppDb.EtlTable(project,"sources.catalog"));
            var objects = CalcObjRows(context);
            var objblocks = blocks(objects);
            TableEmit(objblocks, AppDb.EtlTable<ObjBlock>(project));
            using var alloc = Alloc.create();
            var asmrows = EmitAsmRows(context, alloc);

            //EmitRecoded(context, asmrows);
            // var syms = CalcObjSyms(context);
            // EmitObjSyms(context, syms);
            // CollectCoffData(context);
            // CollectAsmSyntax(context);
            // CollectMcInstructions(context);
            // XedDisasm.Collect(context);
        }

        public static Index<ObjBlock> blocks(Index<ObjDumpRow> src)
        {
            src.Sort();
            var count = src.Count;
            var seq = 0u;
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
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockAddress = @base;
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
                    block.Seq = seq++;
                    block.OriginId = docid;
                    block.BlockName = blockname;
                    block.BlockAddress = @base;
                    block.BlockNumber = number++;
                    block.Source = source;
                    block.BlockSize = size;
                    dst.Add(block);
                }
            }

            return dst.ToArray();
        }

        public static Outcome parse(WsContext context, in FileRef src, out Index<ObjDumpRow> dst)
            => new ObjDumpParser().Parse(context, src, out dst);

        public IDbTargets RecodedTargets(ProjectId id)
            => AppDb.EtlTargets("mc.recoded").Targets(id.Format());

        public FS.FilePath RecodedTarget(ProjectId project, string origin)
            => RecodedTargets(project).Path(origin, FileKind.Asm);

        public FS.FilePath AsmRowPath(ProjectId project, string origin)
            => AppDb.EtlTargets(project).Targets("asm.csv").Path(origin, FileKind.Csv);

        public void EmitObjSyms(WsContext context, ReadOnlySpan<ObjSymRow> src)
            => TableEmit(src, AppDb.EtlTargets(context.Project.Id).Table<ObjSymRow>());

        public void CollectCoffData(WsContext context)
            => Coff.Collect(context);

        public Index<ObjSymRow> CalcObjSyms(WsContext context)
        {
            var result = Outcome.Success;
            var project = context.Project;
            var src = project.OutFiles(FS.Sym).View;
            var count = src.Length;
            var formatter = Tables.formatter<ObjSymRow>();
            var buffer = list<ObjSymRow>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var origin = context.Root(path);
                var fref = context.Ref(path);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line))
                {
                    if(AsmObjects.parse(line.Content, ref counter, out var sym))
                    {
                        sym.Seq = seq++;
                        sym.OriginId = origin.DocId;
                        buffer.Add(sym);
                    }
                }
            }

            return buffer.ToArray();
        }

        public Index<ObjDumpRow> CalcObjRows(WsContext context)
        {
            var project = context.Project;
            var src = project.OutFiles(FileKind.ObjAsm.Ext()).Storage.Sort().Index();
            var result = Outcome.Success;
            var formatter = Tables.formatter<ObjDumpRow>();
            var buffer = bag<ObjDumpRow>();

            iter(src, path => {
                result = parse(context, context.Ref(path), out var records);
                if(result.Fail)
                {
                    Error(result.Message);
                    return;
                }

                var docseq = 0u;
                for(var j=0; j<records.Count; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    buffer.Add(record);
                }
            }, PllExec);

            var data = buffer.ToArray().Sort();
            for(var i=0u; i<data.Length; i++)
                seek(data,i).Seq = i;

            TableEmit(data, AppDb.EtlTable<ObjDumpRow>(project.Project));
            return data;
        }

        public void EmitRecoded(WsContext context, ReadOnlySeq<AsmCodeBlocks> blocks)
        {
            //using var alloc = Alloc.create();
            //var code = EmitAsmRows(context, alloc);
            RecodedTargets(context.Project.Project).Clear();
            for(var i=0; i<blocks.Count; i++)
                RecodeBlocks(context.Project.Id, blocks[i]);
        }

        void RecodeBlocks(ProjectId project, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var asmpath = RecodedTarget(project, src.OriginName.Format());
            var emitting = EmittingFile(asmpath);
            var counter = 0u;
            using var writer = asmpath.AsciWriter();
            writer.WriteLine(intel_syntax);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var block = ref src[i];
                var label = new AsmBlockLabel(block.Label.Name.Format());
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

        public Index<AsmCodeBlocks> EmitAsmRows(WsContext context, Alloc alloc)
        {
            var files = context.Catalog.Entries(FileKind.ObjAsm);
            var count = files.Count;
            var seq = 0u;
            var dst = list<AsmCodeBlocks>();
            for(var i=0; i<count; i++)
            {
                ref readonly var file = ref files[i];
                var result = parse(context, file, out var rows);
                if(result.Fail)
                    Errors.Throw(result.Message);

                var blocks = AsmObjects.blocks(context, file, ref seq, rows, alloc);
                dst.Add(blocks);
                EmitAsmRows(context, blocks, AsmRowPath(context.Project.Project, file.Path.FileName.Format()));
            }
            return dst.ToArray();
        }

        public void EmitAsmRows(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
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
                    record.InstructionId = InstructionId.define(code.OriginId, code.IP, code.Encoding);
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

            TableEmit(buffer, dst);
        }
    }
}