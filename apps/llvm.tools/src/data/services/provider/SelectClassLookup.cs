//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public IdentityMap<Interval<uint>> SelectClassLookup()
            => (IdentityMap<Interval<uint>>)DataSets.GetOrAdd(nameof(SelectClassLookup), key => DataCalcs.CalcIdentityMap(SelectX86ClassMap()));
    }
}