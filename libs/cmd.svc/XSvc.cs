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

            public WfCmd WfCmd(IWfRuntime wf)
                => Service<WfCmd>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public Worlds Worlds(IWfRuntime wf)
                => Service<Worlds>(wf);

            public ToolBoxCmd ToolBoxCmd(IWfRuntime wf)
                => Service<ToolBoxCmd>(wf);

            public ToolScripts WsScripts(IWfRuntime wf)
                => Service<ToolScripts>(wf);

            public CmdExec CmdExec(IWfRuntime wf)
                => Service<CmdExec>(wf);

            public Tooling ToolBoxSvc(IWfRuntime wf)
                => Service<Tooling>(wf);
        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static CheckCmd CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);

        public static IAppCmdSvc WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static ToolScripts WsScripts(this IWfRuntime wf)
            => Services.WsScripts(wf);

        public static IAppCmdSvc ToolBoxCmd(this IWfRuntime wf)
            => Services.ToolBoxCmd(wf);

        public static CmdExec CmdExec(this IWfRuntime wf)
            => Services.CmdExec(wf);

        public static Worlds Worlds(this IWfRuntime wf)
            => Services.Worlds(wf);
 
        public static Tooling Tooling(this IWfRuntime wf)
            => Services.ToolBoxSvc(wf); 
    }
}