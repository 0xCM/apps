//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;
    using static Root;

    partial class LlvmDataCalcs
    {
        public IdentityMap<Interval<uint>> CalcIdentityMap(LineMap<Identifier> src)
        {
            var lookup = new IdentityMap<Interval<uint>>();
            iteri(src.Intervals, (i,entry) => lookup.Map(entry.Id, (entry.MinLine,entry.MaxLine)));
            return lookup;
        }
    }
}