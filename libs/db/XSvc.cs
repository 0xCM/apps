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

            public DumpArchive DumpArchive(IWfRuntime wf)
                => Service<DumpArchive>(wf);

            public ModuleArchives ModuleArchives(IWfRuntime wf)
                => Service<ModuleArchives>(wf);


            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public AppSvcOps<T> AppSvc<T>(IWfRuntime wf)
                where T : IAppService<T>, new()
                    => Service<AppSvcOps<T>>(wf);
        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static ModuleArchives ModuleArchives(this IWfRuntime wf)
            => Services.ModuleArchives(wf);

        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => Services.DumpArchive(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static AppSvcOps<T> AppSvc<T>(this IWfRuntime wf, T svc = default)
            where T : IAppService<T>, new()
                => Services.AppSvc<T>(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf, Type host)
            => Services.AppSvc(wf);
    }
}