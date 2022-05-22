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
            => SelectRecordLines(Datasets.X86);

        public ReadOnlySpan<TextLine> X86RecordLines(Interval<uint> range)
            => slice(X86RecordLines().View, range.Left - 1, range.Right - range.Left + 1);
    }
}