//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

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

        LabelBuffer ClassNameBuffer;

        LabelBuffer DefNameBuffer;

        LlvmTableLoader RecordLoader;

        Index<RecordEntity> _Entities;

        public LlvmDb()
        {
            X86Records = Index<TextLine>.Empty;
            ClassMap = LineMap<Identifier>.Empty;
            DefMap = LineMap<Identifier>.Empty;
            DefLookup = new();
            FieldDefMap = new();
            ClassLookup = new();
            _Entities = Index<RecordEntity>.Empty;
        }

        protected override void Initialized()
        {
            Paths = Wf.LlvmPaths();
            RecordLoader = Wf.LlvmRecordLoader();
            LoadData();
        }

        protected override void Disposing()
        {
            ClassNameBuffer.Dispose();
            DefNameBuffer.Dispose();
        }

        public ReadOnlySpan<RecordField> Fields(uint offset, uint length)
            => slice(_DefFields.View, offset,length);

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

        public RecordEntitySet Entities()
        {
            if(_Entities.IsEmpty)
            {
                var relations = _DefRelations.Map(x => (x.Name.Content, x)).ToDictionary();
                var entites = list<RecordEntity>();
                var current = EmptyString;
                var fields = list<RecordField>();
                var src = DefFields();
                var count = src.Length;
                var relation = default(DefRelations);
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref skip(src,i);
                    if(field.RecordName != current)
                    {
                        if(fields.Count != 0)
                        {
                            entites.Add(new RecordEntity(relation, fields.ToArray()));
                            fields.Clear();
                        }
                        current = field.RecordName;
                        relations.TryGetValue(current, out relation);
                        fields.Add(field);
                    }
                    else
                        fields.Add(field);
                }
                _Entities = entites.ToArray();
            }
            return ("Universe",_Entities);
        }

        public uint EmitClassInfo(StreamWriter dst)
        {
            var count = ClassMap.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(ClassMap[i].Format());
            return count;
        }

        public uint EmitDefInfo(StreamWriter dst)
        {
            var count = DefMap.IntervalCount;
            for(var i=0; i<count; i++)
                dst.WriteLine(DefMap[i].Format());
            return count;
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

        void LoadFields(string dataset, out Index<RecordField> dst)
        {
            var result = RecordLoader.LoadFields(dataset, out dst);
            if(result.Fail)
                Error(result.Message);
        }

        void LoadDefs()
        {
            DefMap = LoadLineMap(Paths.ImportMap(Datasets.X86Defs));
            DefNameBuffer = strings.labels(DefMap.Intervals.Select(x => x.Id.Content));
            iteri(DefMap.Intervals, (i,entry) => DefLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            LoadFields(Datasets.X86DefFields, out _DefFields);
            iteri(DefMap.Intervals, (i,entry) => FieldDefMap.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            _DefRelations = RecordLoader.LoadDefRelations();
        }

        void LoadClasses()
        {
            ClassMap = LoadLineMap(Paths.ImportMap(Datasets.X86Classes));
            ClassNameBuffer = strings.labels(ClassMap.Intervals.Select(x => x.Id.Content));
            iteri(ClassMap.Intervals, (i,entry) => ClassLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            LoadFields(Datasets.X86ClassFields, out _ClassFields);
            _ClassRelations = RecordLoader.LoadClassRelations();
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
    }
}