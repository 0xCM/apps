//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        static ref asci64 segname(string src, out asci64 dst)
        {
            Demand.lteq(src.Length, asci64.Size);
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static BfSegModel seg(string name, uint i0, uint i1, BitMask mask)
            => new BfSegModel(segname(name, out _), i0, i1, mask);

        [MethodImpl(Inline), Op]
        public static BfSegModel<K> seg<K>(K segid, uint i0, uint i1, BitMask mask)
            where K : unmanaged
                => new BfSegModel<K>(segname(segid.ToString(), out _), i0, i1, mask);
    }
}