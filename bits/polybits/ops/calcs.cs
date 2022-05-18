//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline)]
        public static BpCalcs calcs(in BpDef def)
            => new (def);

        public static Index<BpCalcs> calcs(ReadOnlySpan<BpInfo> src)
            => src.Map(p => calcs(p.Def));
    }
}