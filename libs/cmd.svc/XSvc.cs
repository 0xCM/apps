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
            public CheckCmd CheckRunner(IWfRuntime wf)
                => Service<CheckCmd>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public WfCmd WfCmd(IWfRuntime wf)
                => Service<WfCmd>(wf);
        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static IAppCmdSvc WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);

        public static CheckCmd CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);
    }
}