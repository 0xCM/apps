//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public AppDb AppDb(IWfRuntime wf)
                => Service<AppDb>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public CmdLineRunner CmdLineRunner(IWfRuntime wf)
                => Service<CmdLineRunner>(wf);

            public ScriptRunner ScriptRunner(IWfRuntime wf)
                => Service<ScriptRunner>(wf);

            public DumpArchive DumpArchive(IWfRuntime wf)
                => Service<DumpArchive>(wf);
        }

        static Svc Services => Svc.Instance;

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => Services.AppDb(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static void RedirectEmissions(this IWfRuntime wf, string name, FS.FolderPath dst)
            => wf.RedirectEmissions(Loggers.emission(name, dst));

        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => Services.CmdLineRunner(wf);

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => Services.ScriptRunner(wf);

        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => Services.DumpArchive(wf);
    }
}