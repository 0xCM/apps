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
           public MemoryEmitter MemoryEmitter(IWfRuntime wf)
                => Service<MemoryEmitter>(wf);

            public HexCsv HexCsv(IWfRuntime wf)
                => Service<HexCsv>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public HexEmitter HexEmitter(IWfRuntime wf)
                => Service<HexEmitter>(wf);

            public ScriptRunner ScriptRunner(IWfRuntime wf)
                => Service<ScriptRunner>(wf);

            public CmdLineRunner CmdLineRunner(IWfRuntime wf)
                => Service<CmdLineRunner>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);
        }

        static Svc Services => Svc.Instance;

        public static MemoryEmitter MemoryEmitter(this IWfRuntime wf)
            => Services.MemoryEmitter(wf);

        public static HexCsv HexCsv(this IWfRuntime wf)
            => Services.HexCsv(wf);

        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Services.HexEmitter(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => AppData.AppDb;

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => Services.ScriptRunner(wf);

        public static CmdLineRunner CmdLineRunner(this IWfRuntime wf)
            => Services.CmdLineRunner(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);
    }
}