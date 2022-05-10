//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.IO;
    using System.Linq;

    using static core;

    public class AsmTables : AppService<AsmTables>
    {
        public static MsgPattern<Count> ParsingDocs => "Parsing {0} documents";

        public static MsgPattern<FS.FileUri,string> FileParseError => "Error parsing {0}:{1}";

        public AsmTables()
        {
        }

        static Outcome row(uint line, string src, out ProcessAsmRecord dst)
            => row(new TextLine(line, src), out dst);

        static Outcome row(TextLine src, out ProcessAsmRecord dst)
        {
            const string ErrorPattern = "Error parsing {0} on line {1}";
            var parts = src.Split(Chars.Pipe).Map(x => x.Trim());
            var count = parts.Length;
            var outcome = Outcome.Success;
            if(count != ProcessAsmRecord.FieldCount)
            {
                dst = default;
                return (false, AppMsg.CsvDataMismatch.Format(ProcessAsmRecord.FieldCount, count, src.Content));
            }
            dst = default;
            var i=0u;

            outcome += DataParser.parse(skip(parts,i++), out dst.Sequence);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Sequence), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.GlobalOffset);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.GlobalOffset), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.BlockAddress);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.BlockAddress), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.IP);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.IP), src.LineNumber));

            outcome += DataParser.parse(skip(parts,i++), out dst.BlockOffset);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.BlockOffset), src.LineNumber));

            dst.Statement = text.trim(skip(parts,i++));

            outcome += AsmParser.asmhex(skip(parts,i++), out dst.Encoded);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Encoded), src.LineNumber));

            outcome += AsmSigInfo.parse(skip(parts,i++), out dst.Sig);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Sig), src.LineNumber));

            dst.OpCode = new AsmOpCodeString(skip(parts, i++));

            var bitstring = skip(parts,i++);
            dst.Bitstring = asm.bitstring(dst.Encoded);

            outcome += DataParser.parse(skip(parts,i++), out dst.OpUri);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.OpUri), src.LineNumber));

            return true;
        }

        public static Outcome<uint> load(FS.FilePath src, Span<ProcessAsmRecord> dst)
        {
            var counter = 1u;
            var i = 0u;
            var max = dst.Length;
            using var reader = src.AsciReader();
            var header = reader.ReadLine();
            var line = reader.ReadLine();
            var result = Outcome.Success;
            while(line != null && result.Ok)
            {
                result = row(counter++, line, out seek(dst,i));
                if(result.Fail)
                    return result;
                else
                    i++;

                line = reader.ReadLine();
            }
            return i;
        }

        static Outcome<uint> rows(FS.FilePath src, Span<HostAsmRecord> dst)
        {
            const byte FieldCount = HostAsmRecord.FieldCount;

            var result = TextGrids.load(src, out var doc);

            var counter = 0u;
            if(doc.Header.Labels.Length != FieldCount)
                return (false, AppMsg.FieldCountMismatch.Format(FieldCount, doc.Header.Labels.Length));

            var count = (uint)min(doc.RowCount, dst.Length);
            var rows = doc.RowData.View;
            for(var i=0; i<count; i++)
            {
                result = row(skip(rows, i), out seek(dst, i));
                if(result.Fail)
                    return result;
            }
            return count;
        }

        static Outcome<uint> rows(TextGrid doc, Span<HostAsmRecord> dst)
        {
            const byte FieldCount = HostAsmRecord.FieldCount;

            var counter = 0u;
            if(doc.Header.Labels.Length != FieldCount)
                return (false, AppMsg.FieldCountMismatch.Format(FieldCount, doc.Header.Labels.Length));

            var count = (uint)min(doc.RowCount, dst.Length);
            var rows = doc.RowData.View;
            for(var i=0; i<count; i++)
            {
                var result = row(skip(rows, i), out seek(dst, i));
                if(result.Fail)
                    return result;
            }
            return count;
        }

        static Outcome row(in TextRow src, out HostAsmRecord dst)
        {
            const byte FieldCount = HostAsmRecord.FieldCount;
            var result = Outcome.Success;
            var count = src.CellCount;
            var cells = src.Cells;
            dst = default;
            if(src.CellCount != FieldCount)
                return (false, AppMsg.FieldCountMismatch.Format(FieldCount, src.CellCount));

            var i=0;
            result = DataParser.parse(skip(cells, i++), out dst.BlockAddress);
            if(result.Fail)
                return result;

            result = DataParser.parse(skip(cells, i++), out dst.IP);
            if(result.Fail)
                return result;

            result = DataParser.parse(skip(cells, i++), out dst.BlockOffset);
            if(result.Fail)
                return result;

            AsmParser.expression(skip(cells,i++), out dst.Expression);
            dst.Encoded = AsmParser.asmhex(skip(cells, i++));
            result = AsmSigInfo.parse(skip(cells, i++), out dst.Sig);
            if(result.Fail)
                return result;

            dst.OpCode = new AsmOpCodeString(skip(cells, i++));
            dst.Bitstring = asm.bitstring(dst.Encoded);

            result = DataParser.parse(skip(cells, i++), out dst.OpUri);
            if(result.Fail)
                return (false, AppMsg.UriParseFailure.Format(skip(cells,i-1)));

            return result;
        }

        static Outcome<uint> rows(FS.FilePath src, ConcurrentBag<HostAsmRecord> dst)
        {
            const byte FieldCount = HostAsmRecord.FieldCount;
            var result = TextGrids.load(src, out var doc);

            var counter = 0u;
            if(doc.Header.Labels.Length != FieldCount)
                return (false, AppMsg.CsvHeaderMismatch.Format(src, FieldCount, doc.Header.Labels.Length));

            var count = doc.RowCount;
            var rows = doc.RowData.View;
            for(var i=0; i<count; i++)
            {
                result = row(skip(rows,i), out HostAsmRecord statement);
                if(result)
                {
                    dst.Add(statement);
                    counter++;
                }
                else
                    return result;
            }
            return counter;
        }

        static Index<Outcome<uint>> rows(FS.Files src, ConcurrentBag<HostAsmRecord> dst)
        {
            var results = bag<Outcome<uint>>();
            iter(src, path => {
                results.Add(rows(path, dst));
            }, true);
            return results.ToArray();
        }

        static Outcome row(TextRow src, out AsmDetailRow dst)
        {
            var input = src.Cells;
            var i = 0;
            var outcome = Outcome.Empty;
            dst = default;
            outcome = DataParser.parse(skip(input, i++), out dst.Sequence);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.BlockAddress);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.IP);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.GlobalOffset);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.LocalOffset);
            if(!outcome)
                return outcome;

            dst.Mnemonic = new AsmMnemonic(skip(input, i++));
            dst.OpCode = new AsmOpCodeString(skip(input,i++));

            outcome = DataParser.parse(skip(input, i++), out dst.Instruction);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.Statement);
            if(!outcome)
                return outcome;

            outcome = AsmParser.asmhex(skip(input, i++).View, out dst.Encoded);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.CpuId);
            if(!outcome)
                return outcome;

            outcome = DataParser.parse(skip(input, i++), out dst.OpCodeId);
            if(!outcome)
                return outcome;
            return true;
        }

        public Outcome LoadHostRecords(FS.FilePath src, out HostAsmRecord[] dst)
        {
            var result = TextGrids.load(src, out var doc);
            dst = sys.empty<HostAsmRecord>();
            if(result.Fail)
                return result;

            dst = alloc<HostAsmRecord>(doc.RowCount);
            return rows(doc,dst);
        }

        public ReadOnlySpan<AsmDataBlock> DistillBlocks(ReadOnlySpan<HostAsmRecord> records)
        {
            var count = records.Length;
            var buffer = alloc<AsmDataBlock>(count);
            ref var dst = ref first(buffer);
            var block = MemoryAddress.Zero;
            var skipping = false;
            var key = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var record = ref skip(records,i);
                ref readonly var BlockAddress = ref record.BlockAddress;
                ref readonly var Expression = ref record.Expression;
                var newblock = (block != BlockAddress);
                if(!newblock && skipping)
                    continue;

                if(newblock)
                {
                    block = BlockAddress;
                    skipping = false;
                }

                if(Expression.IsInvalid)
                {
                    skipping = true;
                    continue;
                }

                ref var target = ref seek(dst, key++);
                target.Key = key;
                target.BlockAddress = BlockAddress;
                target.IP = record.IP;
                target.BlockOffset = record.BlockOffset;
                target.Expression = Expression.Format();
                target.Encoded = record.Encoded.Format();
                target.Bitstring = record.Bitstring.Format();
                target.Sig = record.Sig.Format();
                target.OpCode = record.OpCode.Format();
            }

            return slice(@readonly(buffer), 0, key);
        }

        public void EmitBlocks(ReadOnlySpan<AsmDataBlock> src, FS.FilePath dst)
        {
            TableEmit(src, AsmDataBlock.RenderWidths, TextEncodingKind.Asci, dst);
        }

        public Index<HostAsmRecord> LoadHostAsmRows(FS.Files src, bool pll = true, bool sort = true)
        {
            const string TableId = HostAsmRecord.TableId;
            var counter = 0u;
            var dst = bag<HostAsmRecord>();
            var flow = Running(string.Format("Parsing {0} records from {1} documents", TableId, src.Count));
            if(pll)
            {
                Status(ParsingDocs.Format(src.Length));
                var results = rows(src, dst);
                foreach(var result in results)
                    result.OnSuccess(count => counter += count).OnFailure(msg => Error(msg));
            }
            else
            {
                foreach(var file in src)
                {
                    var parsed = rows(file, dst);
                    if(parsed.Fail)
                        Error(FileParseError.Format(file, parsed.Message));
                    else
                        counter += parsed.Data;
                }
            }

            Ran(flow, string.Format("Parsed {0} {1} records", counter, TableId));

            var records = dst.ToArray();
            if(sort)
                Array.Sort(records);
            return records;
        }

        public Index<HostAsmRecord> LoadHostAsmRows(FS.FolderPath src, bool pll = true, bool sort = true)
            => LoadHostAsmRows(src.Files(FS.Csv, true), pll, sort);

        public FS.Files AsmDetailFiles()
            => Db.TableDir<AsmDetailRow>().AllFiles;

        public Index<AsmDetailRow> LoadAsmDetails(FS.Files src)
        {
            var records = DataList.create<AsmDetailRow>(Pow2.T18);
            var paths = src;
            var flow = Running(string.Format("Loading {0} asm recordsets", paths.Length));
            var count = paths.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref paths[i];
                var result = LoadDetails(path, records);
                if(result)
                    counter += result.Data;
            }

            Ran(flow, string.Format("Loaded {0} total asm instruction rows", counter));
            return records.Emit();
        }

        public Index<AsmDetailRow> LoadDetails(FS.Files src, AsmMnemonic monic)
        {
            var file = src.FirstOrDefault(f => f.FileName.Contains(monic.Format()));
            if(file.IsEmpty)
                return array<AsmDetailRow>();

            var records = DataList.create<AsmDetailRow>(Pow2.T12);
            var count = LoadDetails(file, records);
            return records.Emit();
        }

        Outcome<Count> LoadDetails(FS.FilePath path, DataList<AsmDetailRow> dst)
        {
            var rowtype = path.FileName.WithoutExtension.Format().RightOfLast(Chars.Dot);
            var flow = Running(string.Format("Loading {0} rows from {1}", rowtype, path.ToUri()));
            var result = TextGrids.load(path, out var doc);
            var kRows = 0;
            if(result)
            {
                var kCells = doc.Header.Labels.Count;
                if(kCells != AsmDetailRow.FieldCount)
                    return (false,string.Format("Found {0} fields in {1} while {2} were expected", kCells, path.ToUri(), AsmDetailRow.FieldCount));

                var rows = doc.Rows;
                kRows = rows.Length;
                for(var j=0; j<kRows; j++)
                {
                    ref readonly var src = ref skip(rows,j);
                    if(src.CellCount != AsmDetailRow.FieldCount)
                        return (false, string.Format("Found {0} fields in {1} while {2} were expected", kCells, src, AsmDetailRow.FieldCount));
                    var loaded = row(src, out AsmDetailRow detail);
                    if(!loaded)
                    {
                        Error(loaded.Message);
                        return false;
                    }

                    dst.Add(detail);
                }

                Ran(flow, string.Format("Loaded {0} {1} rows from {2}", kRows, rowtype, path.ToUri()));
            }
            else
            {
                Error(result.Message);
            }

            return (true,kRows);
        }

        public Index<CpuIdRow> ImportCpuIdData(FS.FolderPath src, FS.FilePath records, FS.FilePath bits)
        {
            var data = CpuIdSvc.import(src);
            EmitRecords(data, records);
            EmitBits(data, bits);
            return data;
        }

        public void ImportCpuIdSources()
            => Emit(CpuIdSvc.import(Ws.Sources().Datasets("sde.cpuid")));

        public void EmitBits(ReadOnlySpan<CpuIdRow> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            CpuIdSvc.EmitBits(src,dst);
            EmittedFile(emitting, src.Length);
        }

        void EmitBits(ReadOnlySpan<CpuIdRow> src)
        {
            var result = Outcome.Success;
            var dst = Ws.Tables().Path("asm.cpuid.bits", FS.Csv);
            var emitting = EmittingFile(dst);
            EmitBits(src,dst);
            EmittedFile(emitting,src.Length);
        }

        public void EmitRecords(ReadOnlySpan<CpuIdRow> src, FS.FilePath dst)
            => EmittedTable(EmittingTable<CpuIdRow>(dst), CpuIdSvc.EmitRecords(src,dst));

        void EmitRows(ReadOnlySpan<CpuIdRow> src)
        {
            var result = Outcome.Success;
            var dst = Ws.Tables().TablePath<CpuIdRow>("tables");
            EmitRecords(src,dst);
        }

        void Emit(ReadOnlySpan<CpuIdRow> src)
        {
            EmitRows(src);
            EmitBits(src);
        }

        public Index<CpuIdRow> ImportCpuId()
        {
            var src = CpuIdSvc.import(Ws.Sources().Datasets("sde.cpuid"));
            EmitRows(src);
            EmitBits(src);
            return src;
        }

    }
}