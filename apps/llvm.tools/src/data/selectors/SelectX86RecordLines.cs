//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static LlvmNames;
    using static core;

    partial class LlvmDataProvider
    {
        public ReadOnlySpan<TextLine> SelectX86RecordLines(Interval<uint> range)
            => slice(SelectX86SourceRecords().View, range.Left - 1, range.Right - range.Left + 1);
    }
}