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
        // public Index<TextLine> SelectLinedRecords()
        // {
        //     return (Index<TextLine>)DataSets.GetOrAdd(nameof(SelectLinedRecords), key => Load());

        //     Index<TextLine> Load()
        //     {
        //         using var reader = LlvmPaths.RecordImport(Datasets.X86Lined, FS.Txt).Utf8LineReader();
        //         return reader.ReadAll().ToArray();
        //     }
        // }

        public ReadOnlySpan<TextLine> SelectX86RecordLines(Interval<uint> range)
            => slice(SelectX86SourceRecords().View, range.Left - 1, range.Right - range.Left + 1);
    }
}