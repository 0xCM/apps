//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ServiceCache : AppServices<ServiceCache>
    {
        public PolyBits PolyBits(IWfRuntime wf)
            => Service<PolyBits>(wf);

        [Op]
        public PbCmd PbCmd(IWfRuntime wf)
            => Service<PbCmd>(wf);

        [Op]
        public BitfieldServices Bitfields(IWfRuntime wf)
            => Service<BitfieldServices>(wf);

        [Op]
        public BitMaskServices ApiBitMasks(IWfRuntime wf)
            => Service<BitMaskServices>(wf);
    }

    public static class XSvc
    {
        static ServiceCache Services => ServiceCache.Instance;

        public static PolyBits PolyBits(this IWfRuntime wf)
            => Services.PolyBits(wf);

        [Op]
        public static PbCmd PbCmd(this IWfRuntime wf)
            => Services.PbCmd(wf);

        [Op]
        public static BitfieldServices Bitfields(this IWfRuntime wf)
            => Services.Bitfields(wf);

        [Op]
        public static BitMaskServices ApiBitMasks(this IWfRuntime wf)
            => Services.ApiBitMasks(wf);
    }
}