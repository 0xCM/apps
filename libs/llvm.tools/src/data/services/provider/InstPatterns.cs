//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmInstPattern> InstPatterns()
            => (Index<LlvmInstPattern>)DataSets.GetOrAdd(nameof(InstPatterns), _ => DataLoader.LoadInstPatterns());
    }
}