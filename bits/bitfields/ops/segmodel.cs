//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        static ref asci64 segname(string src, out asci64 dst)
        {
            Demand.lteq(src.Length, asci64.Size);
            dst = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static BitfieldSegModel segmodel(string name, uint i0, uint i1, BitMask mask)
            => new BitfieldSegModel(segname(name, out _), i0, i1, mask);

        [MethodImpl(Inline), Op]
        public static BitfieldSegModel<K> segmodel<K>(K segid, uint i0, uint i1, BitMask mask)
            where K : unmanaged
                => new BitfieldSegModel<K>(segname(segid.ToString(), out _), i0, i1, mask);
    }
}