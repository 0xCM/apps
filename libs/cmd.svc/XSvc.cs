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
            public CheckRunner CheckRunner(IWfRuntime wf)
                => Service<CheckRunner>(wf);

            public EnvCmd EnvSvc(IWfRuntime wf)
                => Service<EnvCmd>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public AppSvcOps<T> AppSvc<T>(IWfRuntime wf)
                where T : IAppService<T>, new()
                    => Service<AppSvcOps<T>>(wf);
        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);

        public static EnvCmd EnvCmd(this IWfRuntime wf)
            => Services.EnvSvc(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static AppSvcOps<T> AppSvc<T>(this IWfRuntime wf, T svc = default)
            where T : IAppService<T>, new()
                => Services.AppSvc<T>(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf, Type host)
            => Services.AppSvc(wf);
    }
}