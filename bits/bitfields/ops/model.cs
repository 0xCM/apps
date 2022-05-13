//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static BitfieldModel model(BfOrigin origin, string name, Index<BitfieldSegModel> segs)
            => new BitfieldModel(origin, name, segs, Bitfields.totalwidth(segs));
    }
}