//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public Index<TextLine> X86RecordLines()
        {
            var id = Datasets.X86;
            var lookup = DefLineLookup();
            var count = lookup.LineCount;
            using var reader = LlvmPaths.DataSourcePath("records", id).LineReader(TextEncodingKind.Asci);
            var lines = reader.ReadAll().ToArray().Index();
            return (Index<TextLine>)DataSets.GetOrAdd(id + "lines", _ => lines);
        }
            //=> SelectRecordLines(Datasets.X86);

        public ReadOnlySpan<TextLine> X86RecordLines(ClosedInterval<uint> range)
            => slice(X86RecordLines().View, range.Min - 1, range.Max - range.Min + 1);
    }
}