//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public Index<RecordField> DefFields()
            => Fields(LlvmDatasets.X86DefFields);
    }
}