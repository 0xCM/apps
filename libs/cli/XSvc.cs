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
            public CliEmitter CliEmitter(IWfRuntime wf)
                => Service<CliEmitter>(wf);

            public PdbIndexBuilder PdbIndexBuilder(IWfRuntime wf)
                => Service<PdbIndexBuilder>(wf);

            public PdbSymbolStore PdbSymbolStore(IWfRuntime wf)
                => Service<PdbSymbolStore>(wf);

            public Cli Cli(IWfRuntime wf)
                => Service<Cli>(wf);

            public PdbSvc PdbSvc(IWfRuntime wf)
                => Service<PdbSvc>(wf);

            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static CliEmitter CliEmitter(this IWfRuntime wf)
            => Services.CliEmitter(wf);

        public static PdbIndexBuilder PdbIndexBuilder(this IWfRuntime wf)
            => Services.PdbIndexBuilder(wf);

        public static PdbSymbolStore PdbSymbolStore(this IWfRuntime wf)
            => Services.PdbSymbolStore(wf);

        public static PdbSvc PdbSvc(this IWfRuntime wf)
            => Services.PdbSvc(wf);

        public static PdbReader PdbReader(this IWfRuntime wf, in PdbSymbolSource src)
            => Z0.PdbReader.create(wf,src);

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);
    }
}