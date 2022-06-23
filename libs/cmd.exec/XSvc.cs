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
            public ScriptRunner ScriptRunner(IWfRuntime wf)
                => Service<ScriptRunner>(wf);

            public CmdLineRunner CmdLineRunner(IWfRuntime wf)
                => Service<CmdLineRunner>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public ToolBox ToolBox(IWfRuntime wf)
                => Service<ToolBox>(wf);

            public WsScripts WsScripts(IWfRuntime wf)
                => Service<WsScripts>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static WsScripts WsScripts(this IWfRuntime wf)
            => Services.WsScripts(wf);

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => Services.ScriptRunner(wf);

        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => Services.CmdLineRunner(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static ToolBox ToolBox(this IWfRuntime wf)
            => Services.ToolBox(wf);

        public static void RedirectEmissions(this IWfRuntime wf, Assembly src, FS.FolderPath dst, Timestamp? ts = null, string name = null)
            => wf.RedirectEmissions(Loggers.emission(src, dst, ts ?? core.timestamp(), name));
    }
}