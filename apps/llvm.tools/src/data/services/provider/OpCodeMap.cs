//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LlvmOpCodeMap OpCodeMap()
            => (LlvmOpCodeMap)DataSets.GetOrAdd(nameof(OpCodeMap), _ => DataCalcs.CalcOpCodeMap(SelectEntities()));
    }
}