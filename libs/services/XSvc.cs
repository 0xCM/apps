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

            public ScriptRunner ScriptRunner(IWfRuntime wf)
                => Service<ScriptRunner>(wf);

            public CmdLineRunner CmdLineRunner(IWfRuntime wf)
                => Service<CmdLineRunner>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

        }

        static AppSvcCache AppServices => AppSvcCache.Instance;

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => AppServices.ScriptRunner(wf);

        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => AppServices.CmdLineRunner(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => AppServices.OmniScript(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => AppServices.AppSvc(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => GlobalSvc.Instance.AppDb;
    }
}