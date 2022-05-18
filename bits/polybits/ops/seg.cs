//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct BfDatasets
    {
        [MethodImpl(Inline), Op]
        public static BfSegModel seg(string name, uint i0, uint i1, BitMask mask)
            => new BfSegModel(segname(name, out _), i0, i1, mask);

        [MethodImpl(Inline), Op]
        public static BfSegModel<K> seg<K>(K segid, uint i0, uint i1, BitMask mask)
            where K : unmanaged
                => new BfSegModel<K>(segname(segid.ToString(), out _), i0, i1, mask);
    }
}