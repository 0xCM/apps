//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System.Linq;

    using static core;

    public partial class AsmObjects : AppService<AsmObjects>
    {
        public static Outcome parse(WsContext context, in FileRef src, out Index<ObjDumpRow> dst)
            => new ObjDumpParser().ParseSource(context, src, out dst);

        AppDb AppDb => Service(Wf.AppDb);

        AppServices AppSvc => Service(Wf.AppServices);

        CoffServices CoffServices => Service(Wf.CoffServices);

        public ReadOnlySpan<CoffSymRecord> ListSymbols(IProjectWs ws)
        {
            var symbols = LoadSymbols(ws).Symbols();
            return symbols;
        }

        public new AsmObjPaths Paths
        {
            [MethodImpl(Inline)]
            get => AppDb;
        }

        public CoffSymIndex LoadSymbols(IProjectWs ws)
            => CoffServices.LoadSymIndex(ws);

        public Index<ObjDumpRow> LoadRows(IProjectWs project)
            => rows(Paths.ObjRowsPath(project));

        public Index<ObjBlock> LoadBlocks(IProjectWs ws)
            => blocks(Paths.ObjBlockPath(ws));

        public Index<AsmInstructionRow> LoadInstructions(IProjectWs project)
        {
            const byte FieldCount = AsmInstructionRow.FieldCount;
            var src = Paths.InstructionTable(project);
            var lines = slice(src.ReadNumberedLines().View,1);
            var count = lines.Length;
            var buffer = alloc<AsmInstructionRow>(count);
            var result = Outcome.Success;
            for(var i=0; i<count; i++)
            {
                var cells = text.trim(skip(lines,i).Content.Split(Chars.Pipe));
                if(cells.Length != FieldCount)
                {
                    result = (false, Tables.FieldCountMismatch.Format(cells.Length, FieldCount));
                    break;
                }

                ref var dst = ref seek(buffer,i);
                var j = 0;
                result = DataParser.parse(skip(cells, j++), out dst.Seq);
                result = DataParser.parse(skip(cells, j++), out dst.DocSeq);
                result = DataParser.parse(skip(cells, j++), out dst.OriginId);
                result = DataParser.parse(skip(cells, j++), out dst.OriginName);
                result = DataParser.parse(skip(cells, j++), out dst.AsmName);
                result = AsmParser.expression(skip(cells, j++), out dst.Asm);
                result = DataParser.parse(skip(cells, j++), out dst.Source);
            }
            return buffer;
        }
        public void EmitAsmCode(WsContext context)
        {
            using var alloc = Alloc.allocate();
            var code = EmitAsmCode(context, alloc);
            Paths.RecodedTargets(context.Project).Clear();
            for(var i=0; i<code.Count; i++)
                RecodeBlocks(context.Project, code[i]);
        }

        public ObjDumpBlocks CollectObjects(WsContext context)
        {
            var rows = ConsolidateRows(context);
            var blocks = AsmObjects.blocks(rows);
            AppSvc.TableEmit(blocks.View, Paths.ObjBlockPath(context.Project));
            EmitAsmCode(context);
            return new ObjDumpBlocks(blocks,rows);
        }

        void RecodeBlocks(in IProjectWs ws, in AsmCodeBlocks src)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var asmpath = Paths.RecodedPath(ws, src.OriginName.Format());
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

        Index<AsmCodeBlocks> EmitAsmCode(WsContext context, Alloc alloc)
        {
            Paths.AsmTargets(context.Project).Clear();

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

                var blocks = DistillBlocks(context, file, ref seq, rows, alloc);
                dst.Add(blocks);
                EmitAsmCode(context, blocks, Paths.AsmCode(context.Project, file.Path.FileName.Format()));
            }
            return dst.ToArray();
        }

        public void EmitAsmCode(WsContext context, in AsmCodeBlocks src, FS.FilePath dst)
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

        public Index<ObjDumpRow> ConsolidateRows(WsContext context)
        {
            var project = context.Project;
            var src = project.OutFiles(FileKind.ObjAsm).Storage.Sort();
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjDumpRow>(ObjDumpRow.RenderWidths);
            var buffer = bag<ObjDumpRow>();

            iter(src, path => {
                result = parse(context, context.Ref(path), out var records);
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

            TableEmit(@readonly(data), ObjDumpRow.RenderWidths, TextEncodingKind.Asci, Paths.ObjRowsPath(project));
            return data;
        }

        public AsmCodeBlocks DistillBlocks(WsContext context, in FileRef file, ref uint seq, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var blocks = src.GroupBy(x => x.BlockAddress).Array();
            var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
            for(var i=0; i<blocks.Length; i++)
            {
                ref readonly var block = ref skip(blocks,i);
                var blockcode = block.Array();
                var blockname = first(blockcode).BlockName.Format();
                var blockaddress = block.Key;
                var codebuffer = alloc<AsmCode>(blockcode.Length);
                for(var k=0; k<blockcode.Length; k++)
                {
                    ref readonly var row = ref skip(blockcode,k);
                    var encoding = new AsmEncodingInfo();
                    encoding.Seq = seq++;
                    encoding.DocSeq = row.DocSeq;
                    encoding.EncodingId = row.EncodingId;
                    encoding.OriginId = row.OriginId;
                    encoding.InstructionId = row.InstructionId;
                    encoding.IP = row.IP;
                    encoding.Encoded = row.Encoded.Bytes;
                    encoding.Size = row.Size;
                    encoding.Asm = row.Asm.Content;
                    seek(codebuffer,k) = dispenser.AsmCode(encoding);
                }
                seek(blockbuffer,i) = new AsmCodeBlock(dispenser.Symbol(blockaddress,blockname), codebuffer);
            }
            var origin = context.Root(file);
            return new AsmCodeBlocks(dispenser.Label(origin.DocName), origin.DocId, blockbuffer);
        }

        public void MapAsmCode(IProjectWs ws, Alloc dispenser)
        {
            var entries = MapAsmCode(ws, LoadRows(ws), dispenser);
            TableEmit(entries.View, AsmCodeMapEntry.RenderWidths, Paths.CodeMap(ws));
        }

        Index<AsmCodeMapEntry> MapAsmCode(IProjectWs project, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var distilled = DistillBlocks(project, src, dispenser);
            var entries = list<AsmCodeMapEntry>();
            for(var i=0; i<distilled.Count; i++)
            {
                ref readonly var blocks = ref distilled[i];
                if(blocks.Count == 0)
                    continue;

                var blocknumber = 0u;
                var @base = MemoryAddress.Zero;

                for(var j=0; j<blocks.Count; j++)
                {
                    ref readonly var block = ref blocks[j];
                    var count = block.Count;
                    ref readonly var address = ref block.Label.Location.Address;
                    ref readonly var name = ref block.Label.Name;
                    for(var k=0; k<count; k++)
                    {
                        ref readonly var c = ref block[k];

                        if(j==0 && k==0)
                            @base = c.Encoded.BaseAddress;

                        var entry = new AsmCodeMapEntry();
                        entry.Seq = c.Seq;
                        entry.DocSeq = c.DocSeq;
                        entry.EncodingId = c.EncodingId;
                        entry.OriginId = blocks.OriginId;
                        entry.InstructionId = AsmBytes.instid(blocks.OriginId, c.IP, c.Encoding);
                        entry.OriginName = blocks.OriginName;
                        entry.BlockNumber = blocknumber;
                        entry.BlockName = name;
                        entry.BlockAddress = address;
                        entry.IP = c.IP;
                        entry.Size = c.EncodingSize;
                        entry.Encoded = c.Encoded;
                        entry.Asm = c.Asm;
                        entry.BlockSize = block.Size;
                        entries.Add(entry);
                    }

                    blocknumber++;
                }
            }

            var records = entries.ToArray().Sort();
            return records;
        }

        Index<AsmCodeBlocks> DistillBlocks(IProjectWs project, Index<ObjDumpRow> src, Alloc dispenser)
        {
            var collected = dict<uint, AsmCodeBlocks>();
            var groups = src.GroupBy(x => x.OriginId).Array();
            var buffer = alloc<AsmCodeBlocks>(groups.Length);
            for(var i=0; i<groups.Length; i++)
            {
                ref readonly var group = ref skip(groups,i);
                var blocks = group.ToArray().GroupBy(x => x.BlockName).Array();
                if(blocks.Length == 0)
                    continue;

                var blockbuffer = alloc<AsmCodeBlock>(blocks.Length);
                for(var j=0; j<blocks.Length; j++)
                {
                    ref readonly var block = ref skip(blocks,j);
                    var blockcode = block.Array();
                    if(blockcode.Length == 0)
                        continue;

                    var blockname = block.Key.Format();
                    var blockaddress = first(blockcode).BlockAddress;
                    var codebuffer = alloc<AsmCode>(blockcode.Length);
                    for(var k=0; k<blockcode.Length; k++)
                    {
                        ref readonly var row = ref skip(blockcode,k);
                        var encoding = new AsmEncodingInfo();
                        encoding.Seq = row.Seq;
                        encoding.DocSeq = row.DocSeq;
                        encoding.EncodingId = row.EncodingId;
                        encoding.OriginId = row.OriginId;
                        encoding.IP = row.IP;
                        encoding.Encoded = row.Encoded.Bytes;
                        encoding.InstructionId = row.InstructionId;
                        encoding.Size = row.Size;
                        encoding.Asm = row.Asm.Content;
                        seek(codebuffer,k) = dispenser.AsmCode(encoding);
                    }

                    seek(blockbuffer,j) = new AsmCodeBlock(dispenser.Symbol(blockaddress, blockname), codebuffer);
                }

                var origin = FileCatalog.load(project).Entry(group.Key);
                seek(buffer,i) = new AsmCodeBlocks(dispenser.Label(origin.DocName), origin.DocId, blockbuffer);
            }
            return buffer;
        }
    }
}