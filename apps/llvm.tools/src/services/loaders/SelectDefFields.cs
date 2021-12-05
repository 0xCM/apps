//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using static core;
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public Index<RecordField> SelectDefFields()
            => SelectFields(Datasets.X86DefFields);

        public ReadOnlySpan<RecordField> SelectDefFields(uint offset, uint length)
            => slice(SelectFields(Datasets.X86DefFields).View, offset,length);
    }
}