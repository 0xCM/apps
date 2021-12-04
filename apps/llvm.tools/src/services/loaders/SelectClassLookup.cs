//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using System;

    partial class LlvmDataProvider
    {
        public IdentityMap<Interval<uint>> SelectClassLookup()
        {
            return (IdentityMap<Interval<uint>>)DataSets.GetOrAdd(nameof(SelectClassLookup), key => Load());

            IdentityMap<Interval<uint>> Load()
            {
                var lookup = new IdentityMap<Interval<uint>>();
                iteri(SelectX86ClassMap().Intervals, (i,entry) => lookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
                return lookup;
            }
        }

        public IdentityMap<Interval<uint>> SelectDefLookup()
        {
            return (IdentityMap<Interval<uint>>)DataSets.GetOrAdd(nameof(SelectDefLookup), key => Load());

            IdentityMap<Interval<uint>> Load()
            {
                var lookup = new IdentityMap<Interval<uint>>();
                iteri(SelectX86DefMap().Intervals, (i,entry) => lookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
                return lookup;
            }
        }
    }
}