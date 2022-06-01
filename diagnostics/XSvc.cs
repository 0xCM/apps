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
            public DumpArchives DumpArchives(IWfRuntime wf)
                => Service<DumpArchives>(wf);

            public ApiSegmentLocator ApiSegments(IWfRuntime wf)
                => Service<ApiSegmentLocator>(wf);

            public RuntimeServices RuntimeServices(IWfRuntime wf)
                => Service<RuntimeServices>(wf);

        }

        static Svc Services => Svc.Instance;

        public static DumpArchives DumpArchives(this IWfRuntime wf)
            => Services.DumpArchives(wf);

        public static ApiSegmentLocator ApiSegments(this IWfRuntime wf)
            => Services.ApiSegments(wf);

        public static RuntimeServices RuntimeServices(this IWfRuntime wf)
            => Services.RuntimeServices(wf);
    }
}