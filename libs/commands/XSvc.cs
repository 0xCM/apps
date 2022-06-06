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

            public WsCmdRunner WsCmdRunner(IWfRuntime wf)
                => Service<WsCmdRunner>(wf);

            public CheckRunner CheckRunner(IWfRuntime wf)
                => Service<CheckRunner>(wf);

            public MemoryEmitter MemoryEmitter(IWfRuntime wf)
                => Service<MemoryEmitter>(wf);

            public HexCsv HexCsv(IWfRuntime wf)
                => Service<HexCsv>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public HexEmitter HexEmitter(IWfRuntime wf)
                => Service<HexEmitter>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

            public WsProjects WsProjects(IWfRuntime wf)
                => Service<WsProjects>(wf);

        }

        static Svc Services => Svc.Instance;

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => Services.AppDb(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => Services.CmdLineRunner(wf);

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => Services.ScriptRunner(wf);

        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => Services.DumpArchive(wf);

        public static WsCmdRunner WsCmdRunner(this IWfRuntime wf)
            => Services.WsCmdRunner(wf);

        public static CheckRunner CheckRunner(this IWfRuntime wf)
                => Services.CheckRunner(wf);

        public static WsProjects WsProjects(this IWfRuntime wf)
            => Services.WsProjects(wf);

        public static void RedirectEmissions(this IWfRuntime wf, string name, FS.FolderPath dst)
            => wf.RedirectEmissions(Loggers.emission(name, dst));
    }
}