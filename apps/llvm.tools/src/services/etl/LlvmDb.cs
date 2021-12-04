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

        LabelBuffer ClassNameBuffer;

        LabelBuffer DefNameBuffer;

        LlvmDataLoader DataLoader;

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
            DataLoader = Wf.LlvmDataLoader();
            LoadData();
        }

        protected override void Disposing()
        {
            ClassNameBuffer.Dispose();
            DefNameBuffer.Dispose();
        }

        public ReadOnlySpan<Label> ClassNames()
            => ClassNameBuffer.Labels;

        public ReadOnlySpan<Label> DefNames()
            => DefNameBuffer.Labels;

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
            dst = DataLoader.LoadFields(dataset);
        }

        void LoadDefs()
        {
            DefMap = DataLoader.LoadX86DefMap();
            DefNameBuffer = strings.labels(DefMap.Intervals.Select(x => x.Id.Content));
            iteri(DefMap.Intervals, (i,entry) => DefLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            LoadFields(Datasets.X86DefFields, out _DefFields);
            iteri(DefMap.Intervals, (i,entry) => FieldDefMap.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
        }

        void LoadClasses()
        {
            ClassMap = DataLoader.LoadX86ClassMap();
            ClassNameBuffer = strings.labels(ClassMap.Intervals.Select(x => x.Id.Content));
            iteri(ClassMap.Intervals, (i,entry) => ClassLookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            LoadFields(Datasets.X86ClassFields, out _ClassFields);
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


        [MethodImpl(Inline)]
        ReadOnlySpan<TextLine> X86RecordLines(Interval<uint> range)
            => slice(X86Records.View, range.Left - 1, range.Right - range.Left + 1);
    }
}