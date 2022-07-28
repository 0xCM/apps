//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

        }

        static ServiceCache Services = ServiceCache.Instance;

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

    }
}