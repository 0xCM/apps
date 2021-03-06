//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        public static BfModel model(BfOrigin origin, string name, Index<BfSegModel> segs, DataSize size)
            => new BfModel(origin, name, segs, size);

        public static BfModel model(BfOrigin origin, string name, Index<BfSegModel> segs)
            => model(origin, name, segs, minsize(segs));
    }
}