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
            public CliSvc CliSvc(IWfRuntime wf)
                => Service<CliSvc>(wf);

            public CliEmitter CliEmitter(IWfRuntime wf)
                => Service<CliEmitter>(wf);

            public PdbIndexBuilder PdbIndexBuilder(IWfRuntime wf)
                => Service<PdbIndexBuilder>(wf);

            public AppModules AppModules(IWfRuntime wf)
                => Service<AppModules>(wf);

            public PdbSymbolStore PdbSymbolStore(IWfRuntime wf)
                => Service<PdbSymbolStore>(wf);

            public PdbIndex PdbIndex(IWfRuntime wf)
                => Service<PdbIndex>(wf);
        }


        static Svc Services => Svc.Instance;

        public static CliSvc CliSvc(this IWfRuntime wf)
            => Services.CliSvc(wf);

        public static CliEmitter CliEmitter(this IWfRuntime wf)
            => Services.CliEmitter(wf);

        public static PdbIndexBuilder PdbIndexBuilder(this IWfRuntime wf)
            => Services.PdbIndexBuilder(wf);

        public static AppModules AppModules(this IWfRuntime wf)
            => Services.AppModules(wf);

        public static PdbSymbolStore PdbSymbolStore(this IWfRuntime wf)
            => Services.PdbSymbolStore(wf);

        public static PdbReader PdbReader(this IWfRuntime wf, in PdbSymbolSource src)
            => Z0.PdbReader.create(wf,src);

        public static PdbIndex PdbIndex(this IWfRuntime wf)
            => Services.PdbIndex(wf);
    }
}