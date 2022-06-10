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

            public WsScripts WsScripts(IWfRuntime wf)
                => Service<WsScripts>(wf);
        }

        static Svc AppServices => Svc.Instance;


        public static DumpArchive DumpArchive(this IWfRuntime wf)
            => AppServices.DumpArchive(wf);

        public static WsCmdRunner WsCmdRunner(this IWfRuntime wf)
            => AppServices.WsCmdRunner(wf);

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => AppServices.CheckRunner(wf);

        public static WsScripts WsScripts(this IWfRuntime wf)
            => AppServices.WsScripts(wf);

        public static void RedirectEmissions(this IWfRuntime wf, string name, FS.FolderPath dst)
            => wf.RedirectEmissions(Loggers.emission(name, dst));
    }
}