//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public IdentityMap<Interval<uint>> SelectDefLookup()
            => (IdentityMap<Interval<uint>>)DataSets.GetOrAdd(nameof(SelectClassLookup), key => DataCalcs.CalcIdentityMap(X86DefMap()));
    }
}