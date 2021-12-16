//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    partial class LlvmDataProvider
    {
        public Index<LlvmDataType> SelectFieldTypes(ReadOnlySpan<RecordField> src)
            => DataCalcs.CalcFieldTypes(src);
    }
}