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

            public EnvCmd EnvCmd(IWfRuntime wf)
                => Service<EnvCmd>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public DbCmd DbCmd(IWfRuntime wf)
                => Service<DbCmd>(wf);

            public MemCmd MemCmd(IWfRuntime wf)
                => Service<MemCmd>(wf);

            public ToolsetCmd ToolsetCmd(IWfRuntime wf)
                => Service<ToolsetCmd>(wf);

            public AppSvcOps<T> AppSvc<T>(IWfRuntime wf)
                where T : IAppService<T>, new()
                    => Service<AppSvcOps<T>>(wf);
        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);

        public static EnvCmd EnvCmd(this IWfRuntime wf)
            => Services.EnvCmd(wf);

        public static DbCmd DbCmd(this IWfRuntime wf)
            => Services.DbCmd(wf);

        public static MemCmd MemCmd(this IWfRuntime wf)
            => Services.MemCmd(wf);

        public static ToolsetCmd ToolsetCmd(this IWfRuntime wf)
            => Services.ToolsetCmd(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static AppSvcOps<T> AppSvc<T>(this IWfRuntime wf, T svc = default)
            where T : IAppService<T>, new()
                => Services.AppSvc<T>(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf, Type host)
            => Services.AppSvc(wf);
    }
}