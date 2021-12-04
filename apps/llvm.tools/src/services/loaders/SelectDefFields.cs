//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames;

    using System;

    partial class LlvmDataProvider
    {
        public Index<RecordField> SelectClassFields()
            => SelectFields(Datasets.X86ClassFields);

        public Index<RecordField> SelectDefFields()
            => SelectFields(Datasets.X86DefFields);
    }
}