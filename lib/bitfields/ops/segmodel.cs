//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static BitfieldSegModel segmodel(text31 name, byte min, byte max, BitMask mask = default)
            => new BitfieldSegModel(name, min, max, mask);

        public static BitfieldSegModel<K> segmodel<K>(K segid, byte min, byte max, BitMask mask = default)
            where K : unmanaged
                => new BitfieldSegModel<K>(segid.ToString(), min, max, mask);
    }
}