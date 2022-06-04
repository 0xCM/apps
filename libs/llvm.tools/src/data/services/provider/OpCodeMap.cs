//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LlvmOpCodeMap OpCodeMap(Index<LlvmEntity> src)
            => (LlvmOpCodeMap)DataSets.GetOrAdd(nameof(OpCodeMap), _ => Instructions(src));
    }
}