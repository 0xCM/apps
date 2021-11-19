//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public sealed class LlvmRecordLoader : AppService<LlvmRecordLoader>
    {
        LlvmPaths LlvmPaths;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
        }

        public ItemList LoadList(string id)
        {
            var path = LlvmPaths.ListImportPath(id);
            var result = Tables.list(path, out var items);
            if(result.Fail)
            {
                Error(result.Message);
                return ItemList.Empty;
            }
            return items;
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