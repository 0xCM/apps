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
            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);



        }

        static AppSvcCache AppServices => AppSvcCache.Instance;

        public static Tooling Tooling(this IWfRuntime wf)
            => AppServices.Tooling(wf);
    }
}