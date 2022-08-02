//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public ImageRegions ImageRegions(IWfRuntime wf)
                => Service<ImageRegions>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public MemCmd MemCmd(IWfRuntime wf)
                => Service<MemCmd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static ImageRegions ImageRegions(this IWfRuntime wf)
            => Services.ImageRegions(wf);

        public static MemCmd MemCmd(this IWfRuntime wf)
            => Services.MemCmd(wf);

        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);
    }
}