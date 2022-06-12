//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Assets
    {
        public Index<ResEmission> EmitPartAssets()
        {
            var flow = Running("Emitting part assets");
            var src = Assets.assets(ApiRuntimeCatalog.Components).SelectMany(x => x);
            var dst = alloc<ResEmission>(src.Count);
            var counter = 0u;
            for(var i=0; i<src.Count; i++, counter++)
                @try(() => seek(dst,i) = EmitData(src[i], AssetTargets.Root), e => Error(e));
            Ran(flow, string.Format("Emitted <{0}> assets", counter));
            return dst;
        }
    }
}