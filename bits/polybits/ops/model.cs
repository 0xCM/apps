//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        [MethodImpl(Inline), Op]
        public static BfModel model(BfOrigin origin, string name, Index<BfSegModel> segs)
            => new BfModel(origin, name, segs, minsize(segs));
    }
}