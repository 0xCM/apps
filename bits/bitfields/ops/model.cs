//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static BfModel model(BfOrigin origin, string name, Index<BfSegModel> segs)
            => new BfModel(origin, name, segs, Bitfields.totalwidth(segs));
    }
}