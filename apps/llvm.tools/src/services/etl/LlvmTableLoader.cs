//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    public sealed class LlvmTableLoader : AppService<LlvmTableLoader>
    {
        LlvmPaths LlvmPaths;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
        }

        public LlvmList LoadList(string id)
        {
            id = text.begins(id, "llvm.lists.") ? id : "llvm.lists." + id;
            var dst = list<LlvmListItem>();
            var path = LlvmPaths.ListImportPath(id);
            using var reader = path.Utf8LineReader();
            var counter = 0u;
            while(reader.Next(out var line))
            {
                if(counter++ == 0)
                    continue;
                else
                {
                    var parts = line.Content.SplitClean(Chars.Pipe);
                    if(parts.Length != 2)
                    {
                        Error(Tables.FieldCountMismatch.Format(parts.Length, 2));
                        break;
                    }
                    DataParser.parse(skip(parts,0), out uint key);
                    dst.Add((key, skip(parts,1)));
                }
            }
            return (path, dst.ToArray());
        }

        const char Delimiter = Chars.Pipe;

        public Index<LlvmAsmVariation> LoadVariations()
        {
            const byte FieldCount = LlvmAsmVariation.FieldCount;
            var src = LlvmPaths.Table<LlvmAsmVariation>();
            var lines = src.ReadLines();
            var records = Index<LlvmAsmVariation>.Empty;
            if(lines.Length < 1)
            {
                Error(string.Format("Empty file"));
                return records;
            }

            ref readonly var header = ref lines[0];
            var columns = header.SplitClean(Delimiter);
            if(columns.Length != FieldCount)
            {
                Error(Tables.FieldCountMismatch.Format(columns.Length, FieldCount));
                return records;
            }

            var count = lines.Length - 1;
            records = alloc<LlvmAsmVariation>(count);
            for(var i=1;i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var values = @readonly(line.SplitClean(Delimiter));
                if(values.Length != FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(values.Length, FieldCount));
                    break;
                }

                if(text.empty(skip(values,1).Trim()))
                    continue;

                var j=0;
                ref var dst = ref records[i-1];
                DataParser.parse(skip(values,j++), out dst.Key);
                dst.Name = skip(values,j++);
                dst.Mnemonic = skip(values,j++);
                dst.Code =new AsmVariationCode(skip(values,j++));
            }
            return records;
        }

        public static Outcome load(FS.FilePath path, out Span<ValueTypeRow> buffer)
        {
            const byte FieldCount = ValueTypeRow.FieldCount;
            var result = TextGrids.load(path, out var doc);
            buffer = default;
            if(result.Fail)
                return result;

            var rows = doc.Rows;
            var count = rows.Length;
            buffer = span<ValueTypeRow>(count);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var src = ref skip(rows,i);
                if(src.CellCount != FieldCount)
                {
                    result = (false, AppMsg.FieldCountMismatch.Format(FieldCount,src.CellCount));
                    break;
                }

                var cells = src.Cells;
                var cell = TextBlock.Empty;

                var j=0;
                cell = skip(cells, j++);
                if(!DataParser.block(cell, out dst.Namespace))
                {
                    result = (false, string.Format("Failed to parse field '{0}' from input '{1}'", nameof(dst.Namespace), cell));
                    break;
                }

                cell = skip(cells, j++);
                if(!DataParser.parse(cell, out dst.Size))
                {
                    result = (false, string.Format("Failed to parse field '{0}' from input '{1}'", nameof(dst.Size), cell));
                    break;
                }

                cell = skip(cells, j++);
                if(!DataParser.parse(cell, out dst.Value))
                {
                    result = (false, string.Format("Failed to parse field '{0}' from input '{1}'", nameof(dst.Value), cell));
                    break;
                }

                counter++;
            }

            buffer = slice(buffer, 0, counter);
            return result;
        }

        public Index<DefRelations> LoadDefRelations()
        {
            var src = LlvmPaths.Table<DefRelations>();
            var dst = list<DefRelations>();
            var rows = src.ReadLines();
            var count = rows.Length;
            var result = Outcome.Success;
            for(var i=1; i<count; i++)
            {
                var record = new DefRelations();
                ref readonly var row = ref rows[i];
                var cells = @readonly(row.Split(Chars.Pipe).Select(x => x.Trim()));
                if(cells.Length != llvm.DefRelations.FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(llvm.DefRelations.FieldCount, cells.Length));
                    Write(row);
                    break;
                }
                var j=0;
                result = DataParser.parse(skip(cells, j++), out record.SourceLine);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                result = DataParser.parse(skip(cells, j++), out record.Name);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                record.Ancestors = Lineage.parse(skip(cells, j++));
                dst.Add(record);
            }
            return dst.ToArray();
        }

        public Index<ClassRelations> LoadClassRelations()
        {
            var src = LlvmPaths.Table<ClassRelations>();
            var dst = list<ClassRelations>();
            var rows = src.ReadLines();
            var count = rows.Length;
            var result = Outcome.Success;
            for(var i=1; i<count; i++)
            {
                var record = new ClassRelations();
                ref readonly var row = ref rows[i];
                var cells = @readonly(row.Split(Chars.Pipe).Select(x => x.Trim()));
                if(cells.Length != llvm.ClassRelations.FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(llvm.ClassRelations.FieldCount, cells.Length));
                    Write(row);
                    break;
                }
                var j=0;
                result = DataParser.parse(skip(cells,j++), out record.SourceLine);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                result = DataParser.parse(skip(cells,j++), out record.Name);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                record.Ancestors = Lineage.parse(skip(cells, j++));
                record.Parameters = skip(cells,j++);
                dst.Add(record);
            }
            return dst.ToArray();
        }

        public Outcome LoadFields(string dsid, out Index<RecordField> dst)
            => LoadFields(LlvmPaths.Table(dsid), out dst);

        public Outcome LoadFields(FS.FilePath src, out Index<RecordField> dst)
        {
            var count = FS.linecount(src);
            var result = Outcome.Success;
            dst = alloc<RecordField>(count.Lines);
            var counter = 0u;
            using var reader = src.Utf8LineReader();
            var id = Identifier.Empty;
            var i = 0u;
            var j = 0u;
            while(reader.Next(out var line))
            {
                result = parse(line, out var field);
                if(result.Fail)
                    break;
                dst[counter++] = field;
            }
            return result;
        }

        static Outcome parse(in TextLine src, out RecordField dst)
        {
            var result = Outcome.Success;
            dst = default;
            var parts = src.Split(Z0.Chars.Pipe).Map(x => x.Trim());
            var count = parts.Length;
            if(count < 4)
                return (false, Tables.FieldCountMismatch.Format(4, count));

            dst.RecordName = skip(parts,0);
            dst.DataType = skip(parts,1);
            dst.Name = skip(parts,2);
            dst.Value = skip(parts,3);
            return result;
        }
    }
}