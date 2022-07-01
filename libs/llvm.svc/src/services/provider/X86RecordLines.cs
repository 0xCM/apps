//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<TextLine> X86RecordLines()
        {
            var id = LlvmDatasets.dataset(LlvmTargetName.x86).Records;
            using var reader = LlvmPaths.RecordSource(id).LineReader(TextEncodingKind.Asci);
            var lines = reader.ReadAll().ToArray().Index();
            return (Index<TextLine>)DataSets.GetOrAdd(id + "lines", _ => lines);
        }

        public ReadOnlySpan<TextLine> X86RecordLines(ClosedInterval<uint> range)
            => slice(X86RecordLines().View, range.Min - 1, range.Max - range.Min + 1);
    }
}