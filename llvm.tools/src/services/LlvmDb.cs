//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using records;

    using static Root;
    using static LlvmNames;
    using static core;

    public sealed class LlvmDb : AppService<LlvmDb>
    {
        new LlvmPaths Paths;

        Index<TextLine> X86Records;

        LineMap<Identifier> ClassMap;

        LineMap<Identifier> DefMap;

        IdentityMap<Interval<uint>> DefLookup;

        IdentityMap<Interval<uint>> ClassLookup;

        Index<RecordField> _DefFields;

        Index<RecordField> _ClassFields;

        IdentityMap<Interval<uint>> FieldDefMap;

        Index<DefRelations> _DefRelations;

        Index<ClassRelations> _ClassRelations;

        BufferedLabels ClassNameBuffer;

        BufferedLabels DefNameBuffer;

        public LlvmDb()
        {
            X86Records = Index<TextLine>.Empty;
            ClassMap = LineMap<Identifier>.Empty;
            DefMap = LineMap<Identifier>.Empty;
            DefLookup = new();
            FieldDefMap = new();
            ClassLookup = new();
        }

        protected override void Initialized()
        {
            Paths = Wf.LlvmPaths();
            LoadData();
        }

        protected override void Disposing()
        {
            ClassNameBuffer.Dispose();
            DefNameBuffer.Dispose();
        }

        public ReadOnlySpan<RecordField> Fields(uint offset, uint length)
            => slice(_DefFields.View, offset,length);

        public ReadOnlySpan<RecordField> SelectFields(Identifier id)
        {
            if(FieldDefMap.Mapped(id, out var interval))
            {
                var i = interval.Left;
                var j = interval.Right;
                return slice(_DefFields.View, i, j - i);
            }
            else
            {
                Warn(string.Format("{0} not found", id));
                return default;
            }
        }

        public ItemList SelectList(string id)
        {
            var path = Paths.ListImportPath(id);
            var result = Tables.list(path, out var items);
            if(result.Fail)
            {
                Error(result.Message);
                return ItemList.Empty;
            }
            return items;
        }


        public ReadOnlySpan<Label> ClassNames()
            => ClassNameBuffer.Labels;

        public ReadOnlySpan<Label> DefNames()
            => DefNameBuffer.Labels;

        public ReadOnlySpan<RecordField> ClassFields()
            => _ClassFields.View;

        public ReadOnlySpan<RecordField> DefFields()
            => _DefFields.View;

        public ReadOnlySpan<ClassRelations> ClassRelations()
            => _ClassRelations;

        public ReadOnlySpan<DefRelations> DefRelations()
            => _DefRelations;

        public void QueryFields(Action<IFieldProvider> receiver)
        {
            var defcount = DefMap.IntervalCount;
            for(var i=0; i<defcount; i++)
                receiver(new FieldProvider(DefMap[i].Id, this));
        }

        public void EmitClassInfo(StreamWriter dst)
        {
            var count = ClassMap.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(ClassMap[i].Format());
        }

        public void EmitDefInfo(StreamWriter dst)
        {
            var count = DefMap.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(DefMap[i].Format());
        }

        public ReadOnlySpan<TextLine> SelectDefLines(Identifier name)
        {
            if(DefLookup.Mapped(name, out var interval))
                return X86RecordLines(interval);
            else
                Write(AppMsg.NotFound.Format(name));
            return default;
        }

        public ReadOnlySpan<TextLine> SelectClassLines(Identifier name)
        {
            var lines = list<TextLine>();
            if(ClassLookup.Mapped(name, out var interval))
                return X86RecordLines(interval);
            else
                Write(AppMsg.NotFound.Format(name));
            return lines.ViewDeposited();
        }

        void LoadClassRelations()
        {
            var src = Paths.Table<ClassRelations>();
            var dst = list<ClassRelations>();
            var rows = src.ReadLines();
            var count = rows.Length;
            var result = Outcome.Success;
            for(var i=1; i<count; i++)
            {
                var record = new ClassRelations();
                ref readonly var row = ref rows[i];
                var cells = @readonly(row.Split(Chars.Pipe).Select(x => x.Trim()));
                if(cells.Length != records.ClassRelations.FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(records.ClassRelations.FieldCount, cells.Length));
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
            _ClassRelations = dst.ToArray();
        }

        void LoadDefRelations()
        {
            var src = Paths.Table<DefRelations>();
            var dst = list<DefRelations>();
            var rows = src.ReadLines();
            var count = rows.Length;
            var result = Outcome.Success;
            for(var i=1; i<count; i++)
            {
                var record = new DefRelations();
                ref readonly var row = ref rows[i];
                var cells = @readonly(row.Split(Chars.Pipe).Select(x => x.Trim()));
                if(cells.Length != records.DefRelations.FieldCount)
                {
                    Error(Tables.FieldCountMismatch.Format(records.DefRelations.FieldCount, cells.Length));
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
            _DefRelations = dst.ToArray();
        }

        void LoadFields(string dataset, out Index<RecordField> dst)
        {
            var src = Paths.Table(dataset);
            var count = FS.linecount(src);
            dst = alloc<RecordField>(count.Lines);
            var counter = 0u;
            using var reader = src.Utf8LineReader();
            var id = Identifier.Empty;
            var i = 0u;
            var j = 0u;
            while(reader.Next(out var line))
            {
                var result = parse(line, out var field);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }

                dst[counter++] = field;
            }
        }

        void LoadDefs()
        {
            DefMap = LoadLineMap(Paths.ImportMap(Datasets.X86Defs));
            DefNameBuffer = strings.labels(DefMap.Intervals.Select(x => x.Id.Content));
            iteri(DefMap.Intervals, (i,entry) => DefLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            LoadFields(Datasets.X86DefFields, out _DefFields);
            iteri(DefMap.Intervals, (i,entry) => FieldDefMap.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            LoadDefRelations();
        }

        void LoadClasses()
        {
            ClassMap = LoadLineMap(Paths.ImportMap(Datasets.X86Classes));
            ClassNameBuffer = strings.labels(ClassMap.Intervals.Select(x => x.Id.Content));
            iteri(ClassMap.Intervals, (i,entry) => ClassLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            LoadFields(Datasets.X86ClassFields, out _ClassFields);
            LoadClassRelations();
        }

        void LoadRecordLines()
        {
            using var reader = Paths.RecordImport(Datasets.X86Lined, FS.Txt).Utf8LineReader();
            X86Records = reader.ReadAll().ToArray();
        }

        void LoadData()
        {
            var flow = Running("Loading data");
            LoadRecordLines();
            LoadClasses();
            LoadDefs();
            Ran(flow, string.Format("Loaded {0} fields from {1} records", _DefFields.Count, X86Records.Count));
        }

        LineMap<Identifier> LoadLineMap(FS.FilePath src)
        {
            using var reader = src.Utf8LineReader();
            var lines = reader.ReadAll();
            var interval = LineInterval<Identifier>.Empty;
            var count = lines.Length;
            var intervals = alloc<LineInterval<Identifier>>(count);
            var result = Outcome.Success;
            for(var i=0u; i<count; i++)
            {
                ref var dst = ref seek(intervals, i);
                result = DataParser.parse(skip(lines,i).Content, out seek(intervals,i));
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
            }

            if(result)
                return new LineMap<Identifier>(intervals);
            else
                return new LineMap<Identifier>(sys.empty<LineInterval<Identifier>>());
        }

        [MethodImpl(Inline)]
        ReadOnlySpan<TextLine> X86RecordLines(Interval<uint> range)
            => slice(X86Records.View, range.Left - 1, range.Right - range.Left + 1);

        static Outcome parse(in TextLine src, out RecordField dst)
        {
            var result = Outcome.Success;
            dst = default;
            var parts = src.Split(Z0.Chars.Pipe);
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