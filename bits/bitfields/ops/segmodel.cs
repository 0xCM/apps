//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static BitfieldSegModel segmodel(string name, uint i0, uint i1, BitMask mask)
        {
            Demand.lteq(name.Length, asci32.Size);
            return new BitfieldSegModel(name, i0, i1, mask);
        }

        public static BitfieldSegModel<K> segmodel<K>(K segid, uint i0, uint i1, BitMask mask)
            where K : unmanaged
                => new BitfieldSegModel<K>(segid.ToString(), i0, i1, mask);
    }
}