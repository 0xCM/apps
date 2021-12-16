//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public Index<LlvmInstPattern> SelectInstPatterns()
            => (Index<LlvmInstPattern>)DataSets.GetOrAdd(nameof(SelectInstPatterns), _ => DataLoader.LoadInstPatterns());
    }
}