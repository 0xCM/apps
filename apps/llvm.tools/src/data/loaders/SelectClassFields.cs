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
        public Index<RecordField> SelectClassFields()
            => SelectFields(Datasets.X86ClassFields);

        public ReadOnlySpan<RecordField> SelectClassFields(uint offset, uint length)
            => slice(SelectFields(Datasets.X86ClassFields).View, offset,length);
    }
}