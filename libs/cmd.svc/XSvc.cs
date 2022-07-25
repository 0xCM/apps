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

            public WfCmd WfCmd(IWfRuntime wf)
                => Service<WfCmd>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public ToolsetCmd ToolsetCmd(IWfRuntime wf)
                => Service<ToolsetCmd>(wf);

            public CmdLineRunner CmdLineRunner(IWfRuntime wf)
                => Service<CmdLineRunner>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public ToolBox ToolBox(IWfRuntime wf)
                => Service<ToolBox>(wf);

            public WsScripts WsScripts(IWfRuntime wf)
                => Service<WsScripts>(wf);

            public  Toolsets Toolsets(IWfRuntime wf)
                => Service<Toolsets>(wf);

            public CmdExec CmdExec(IWfRuntime wf)
                => Service<CmdExec>(wf);

        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);

        public static WfCmd WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);

        public static ToolsetCmd ToolsetCmd(this IWfRuntime wf)
            => Services.ToolsetCmd(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static WsScripts WsScripts(this IWfRuntime wf)
            => Services.WsScripts(wf);

        public static CmdLineRunner CmdLines(this IWfRuntime wf)
            => Services.CmdLineRunner(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static ToolBox ToolBox(this IWfRuntime wf)
            => Services.ToolBox(wf);

        public static Toolsets Toolsets(this IWfRuntime wf)
            => Services.Toolsets(wf);

        public static CmdExec CmdExec(this IWfRuntime wf)
            => Services.CmdExec(wf);
    }
}