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

        internal sealed class SvcCache : Services<SvcCache>
        {
            public AppDb AppDb()
                => Service<AppDb>();
        }


        static AppSvcCache AppServices => AppSvcCache.Instance;

        static SvcCache Services => SvcCache.Instance;

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => AppServices.AppSvc(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => GlobalSvc.Instance.AppDb;
    }
}