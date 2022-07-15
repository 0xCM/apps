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

        static ServiceCache Services => ServiceCache.Instance;

        public static WsScripts WsScripts(this IWfRuntime wf)
            => Services.WsScripts(wf);

        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
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