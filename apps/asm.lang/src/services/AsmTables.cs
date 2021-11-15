//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;
    using System.Linq;

    using static Root;
    using static core;

    public class AsmTables : AppService<AsmTables>
    {
        public AsmTables()
        {
        }

        public FS.Files AsmDetailFiles()
            => Db.TableDir<AsmDetailRow>().AllFiles;

        public Index<AsmDetailRow> LoadAsmDetails()
        {
            var records = DataList.create<AsmDetailRow>(Pow2.T18);
            var paths = AsmDetailFiles().View;
            var flow = Running(string.Format("Loading {0} asm recordsets", paths.Length));
            var count = paths.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(paths,i);
                var result = LoadDetails(path, records);
                if(result)
                    counter += result.Data;
            }

            Ran(flow, string.Format("Loaded {0} total asm instruction rows", counter));
            return records.Emit();
        }

        public Index<AsmDetailRow> LoadDetails(AsmMnemonicCode monic)
        {
            var file = AsmDetailFiles().FirstOrDefault(f => f.FileName.Contains(monic.ToString()));
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
                    var loaded = AsmParser.row(src, out AsmDetailRow row);
                    if(!loaded)
                    {
                        Error(loaded.Message);
                        return false;
                    }

                    dst.Add(row);
                }

                Ran(flow, string.Format("Loaded {0} {1} rows from {2}", kRows, rowtype, path.ToUri()));
            }
            else
            {
                Error(result.Message);
            }

            return (true,kRows);
        }

        public uint RenderRows(AsmMnemonicCode code, FS.FilePath dst)
        {
            var rows = @readonly(LoadDetails(code).OrderBy(x => x.Statement).Array());
            var count = rows.Length;
            if(count == 0)
                return 0;

            using var writer = dst.Writer();

            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                var rendered = string.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9}",
                    row.IP,
                    row.Statement,
                    row.BlockAddress,
                    row.LocalOffset,
                    row.Encoded.Length,
                    row.Instruction,
                    row.OpCode,
                    row.Encoded,
                    AsmRender.format8x4(row.Encoded),
                    AsmRender.semantic(row)
                );
                writer.WriteLine(rendered);
            }
            return (uint)count;
        }

        public Outcome LoadCpuIdImports(IWorkspace ws, out ReadOnlySpan<CpuIdRow> rows)
        {
            const byte FieldCount = CpuIdRow.FieldCount;
            const char Delimiter = Chars.Pipe;
            rows = default;
            var result = Outcome.Success;
            var src = ws.TablePath<CpuIdRow>();

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

                result = AsmParser.row(data, out CpuIdRow row);
                if(result.Fail)
                    return result;

                dst.Add(row);

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
            var dst = Ws.Tables().TablePath<CpuIdRow>();
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

                var result = AsmParser.row(data, out CpuIdRow row);
                if(result.Fail)
                {
                    Error(result.Message);
                    return default;
                }

                dst.Add(row);

                current = reader.ReadLine();
            }

            return dst.ViewDeposited();
        }
    }
}