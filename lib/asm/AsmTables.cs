//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static Root;
    using static core;

    public class AsmTables : AppService<AsmTables>
    {
        public static MsgPattern<Count,FS.FilePath> LoadedForms => "Loaded {0} forms from {1}";

        public static MsgPattern<FS.FolderPath> LoadingStatements => "Loading asm statement rows from directory {0}";

        public static MsgPattern<Count> ParsedStatements => "Parsed {0} asm statement rows";

        public static MsgPattern<Count> LoadingDocs => "Loading {0} documents";

        public static MsgPattern<Count> ParsingDocs => "Parsing {0} documents";

        public static MsgPattern<FS.FileUri,string> FileParseError => "Error parsing {0}:{1}";


        public AsmTables()
        {
        }

        static Outcome row(TextRow src, out CpuIdRow dst)
        {
            var input = src.Cells;
            var i = 0;
            var outcome = Outcome.Success;
            outcome += DataParser.parse(skip(input,i++), out dst.Chip);
            outcome += DataParser.parse(skip(input,i++), out dst.Leaf);
            outcome += DataParser.parse(skip(input,i++), out dst.Subleaf);
            outcome += DataParser.parse(skip(input,i++), out dst.Eax);
            outcome += DataParser.parse(skip(input,i++), out dst.Ebx);
            outcome += DataParser.parse(skip(input,i++), out dst.Ecx);
            outcome += DataParser.parse(skip(input,i++), out dst.Edx);
            return outcome;
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

            outcome += AsmParser.asmxpr(skip(parts,i++), out dst.Statement);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Statement), src.LineNumber));

            outcome += AsmHexCode.parse(skip(parts,i++), out dst.Encoded);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Encoded), src.LineNumber));

            outcome += AsmParser.siginfo(skip(parts,i++), out dst.Sig);
            if(outcome.Fail)
                return (false, string.Format(ErrorPattern, nameof(dst.Sig), src.LineNumber));

            dst.OpCode = new AsmOpCodeString(skip(parts, i++));

            var bitstring = skip(parts,i++);
            dst.Bitstring = dst.Encoded;

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

            dst.Expression = AsmExpr.parse(skip(cells, i++));
            dst.Encoded = AsmHexCode.parse(skip(cells, i++));
            result = AsmParser.siginfo(skip(cells, i++), out dst.Sig);
            if(result.Fail)
                return result;

            dst.OpCode = new AsmOpCodeString(skip(cells, i++));
            dst.Bitstring = dst.Encoded;

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

            outcome = AsmHexCode.parse(skip(input, i++).View, out dst.Encoded);
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

        // public uint RenderRows(FS.Files src, AsmMnemonic mnemonic, FS.FilePath dst)
        // {
        //     var rows = @readonly(LoadDetails(src, mnemonic).OrderBy(x => x.Statement).Array());
        //     var count = rows.Length;
        //     if(count == 0)
        //         return 0;

        //     using var writer = dst.Writer();
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var row = ref skip(rows,i);
        //         var rendered = string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9}",
        //             row.IP,
        //             row.Statement,
        //             row.BlockAddress,
        //             row.LocalOffset,
        //             row.Encoded.Size,
        //             row.Instruction,
        //             row.OpCode,
        //             row.Encoded,
        //             row.Encoded.ToBitString(),
        //             AsmRender.semantic(row)
        //         );
        //         writer.WriteLine(rendered);
        //     }
        //     return (uint)count;
        // }

        public Outcome LoadCpuIdImports(IWorkspace ws, out ReadOnlySpan<CpuIdRow> rows)
        {
            const byte FieldCount = CpuIdRow.FieldCount;
            const char Delimiter = Chars.Pipe;
            rows = default;
            var result = Outcome.Success;
            var src = ws.TablePath<CpuIdRow>("tables");

            using var reader = src.Utf8Reader();
            var header = TextGrids.header(reader.ReadLine(), Delimiter);
            var count = header.Length;
            if(count != FieldCount)
                return (false, Tables.FieldCountMismatch.Format(FieldCount,count));

            var current = reader.ReadLine();
            var dst = list<CpuIdRow>();
            while(current != null)
            {
                var data = text.row(current,Chars.Pipe);
                if(data.CellCount != FieldCount)
                    return (false, Tables.FieldCountMismatch.Format(FieldCount, data.CellCount));

                result = row(data, out CpuIdRow cpuid);
                if(result.Fail)
                    return result;

                dst.Add(cpuid);

                current = reader.ReadLine();
            }

            rows = dst.ViewDeposited();

            return result;
        }

        public Outcome ImportCpuIdSources()
        {
            //2 space-separated 32-bit hex numbers
            const byte InLength = 2*8 + 1;

            //4 32-bit hex numbers interspersed with spaces
            const byte OutLength = 4*8 + 3;

            const string Imply = " => ";

            var srcdir = Ws.Sources().Datasets("sde.cpuid");
            var srcfiles = srcdir.Files(FS.Def, true).ToReadOnlySpan();
            var count = srcfiles.Length;
            var outcome = Outcome.Success;
            var records = list<CpuIdRow>();

            for(var i=0; i<count; i++)
            {
                if(outcome.Fail)
                    break;

                ref readonly var file = ref skip(srcfiles,i);
                var chip = file.FolderName.Format();
                using var reader = file.LineReader(TextEncodingKind.Asci);
                while(reader.Next(out var line))
                {
                    if(line.StartsWith(Chars.Hash))
                        continue;

                    var content = line.Content;
                    var index = text.index(content, Imply);
                    if(index != NotFound)
                    {
                        var row = new CpuIdRow();
                        var input = text.left(content, index);
                        var iargs = input.Split(Chars.Space).ToReadOnlySpan();
                        if(iargs.Length != 2)
                        {
                            outcome = (false, "Line did not split on marker");
                            break;
                        }

                        outcome = DataParser.parse(skip(iargs,0), out row.Leaf);
                        if(outcome.Fail)
                        {
                            outcome = (false, "Failed to parse eax");
                            break;
                        }

                        if(skip(iargs,1).Contains(Chars.Star))
                            row.Subleaf = uint.MaxValue;
                        else
                            outcome = DataParser.parse(skip(iargs,1), out row.Subleaf);

                        if(outcome.Fail)
                        {
                            outcome = (false, "Failed to parse ecx");
                            break;
                        }

                        var output = text.right(content,index);
                        if(output.Length < OutLength)
                        {
                            outcome = (false, "Output length too short");
                            break;
                        }

                        var outvals = text.slice(output, 0, OutLength).Trim().Split(Chars.Space).ToReadOnlySpan();
                        if(outvals.Length < 5)
                        {
                            outcome = (false, string.Format("Output count = {0}, expected at least {1}", outvals.Length, OutLength));
                            break;
                        }
                        row.Chip = chip;
                        outcome = DataParser.parse(skip(outvals,1), out row.Eax);
                        if(outcome.Fail)
                            break;

                        outcome = DataParser.parse(skip(outvals,2), out row.Ebx);
                        if(outcome.Fail)
                            break;

                        outcome = DataParser.parse(skip(outvals,3), out row.Ecx);
                        if(outcome.Fail)
                            break;

                        outcome = DataParser.parse(skip(outvals,4), out row.Edx);
                        if(outcome.Fail)
                            break;

                        if(outcome)
                            records.Add(row);
                    }
                }
           }

            var deposited = records.ViewDeposited();
            if(outcome)
                outcome = Emit(deposited);
            else
                Error(outcome.Message);

            return outcome;
        }

        Outcome Emit(ReadOnlySpan<CpuIdRow> src)
        {
            var result = EmitRows(src);
            if(result)
                result = EmitBits(src);
            return result;
        }

        Outcome EmitBits(ReadOnlySpan<CpuIdRow> src)
        {
            var result = Outcome.Success;
            var dst = Ws.Tables().Path("asm.cpuid.bits", FS.Csv);
            var flow = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            AsmRender.regvals(src, buffer);
            writer.WriteLine(buffer.Emit());
            EmittedFile(flow,src.Length);
            return result;
        }

        Outcome EmitRows(ReadOnlySpan<CpuIdRow> src)
        {
            var result = Outcome.Success;
            var dst = Ws.Tables().TablePath<CpuIdRow>("tables");
            var flow = Wf.EmittingTable<CpuIdRow>(dst);
            var formatter = Tables.formatter<CpuIdRow>(CpuIdRow.RenderWidths);
            using var rowWriter = dst.AsciWriter();
            rowWriter.WriteLine(formatter.FormatHeader());
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(src,i);
                rowWriter.WriteLine(formatter.Format(row));
            }
            Wf.EmittedTable(flow, count);
            return result;
        }

        ReadOnlySpan<CpuIdRow> LoadCpuIdImports(TextReader reader)
        {
            const byte FieldCount = CpuIdRow.FieldCount;
            const char Delimiter = Chars.Pipe;

            var header = TextGrids.header(reader.ReadLine(), Delimiter);
            var count = header.Length;
            if(count != FieldCount)
            {
                Error(Tables.FieldCountMismatch.Format(FieldCount,count));
                return default;
            }

            var current = reader.ReadLine();
            var dst = list<CpuIdRow>();
            while(current != null)
            {
                var data = text.row(current,Chars.Pipe);
                if(data.CellCount != FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(FieldCount, data.CellCount));
                    return default;
                }

                var result = row(data, out CpuIdRow cpuid);
                if(result.Fail)
                {
                    Error(result.Message);
                    return default;
                }

                dst.Add(cpuid);

                current = reader.ReadLine();
            }

            return dst.ViewDeposited();
        }
    }
}