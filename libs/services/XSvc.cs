//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class AppSvcCache : AppServices<AppSvcCache>
        {
            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

        }

        static AppSvcCache AppServices => AppSvcCache.Instance;


        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => AppServices.AppSvc(wf);
    }
}