//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LlvmOpCodeMap SelectOpCodeMap()
            => (LlvmOpCodeMap)DataSets.GetOrAdd(nameof(SelectOpCodeMap), _ => DataCalcs.CalcOpCodeMap(SelectEntities()));
    }
}