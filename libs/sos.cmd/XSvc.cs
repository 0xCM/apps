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

            public PdbIndexBuilder PdbIndexBuilder(IWfRuntime wf)
                => Service<PdbIndexBuilder>(wf);

            public PdbSymbols PdbSymbolStore(IWfRuntime wf)
                => Service<PdbSymbols>(wf);

            public PdbSvc PdbSvc(IWfRuntime wf)
                => Service<PdbSvc>(wf);

            public SosCmd SosCmd(IWfRuntime wf)
                => Service<SosCmd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static SosCmd SosCmd(this IWfRuntime wf)
            => Services.SosCmd(wf);

        public static PdbIndexBuilder PdbIndexBuilder(this IWfRuntime wf)
            => Services.PdbIndexBuilder(wf);

        public static PdbSymbols PdbSymbolStore(this IWfRuntime wf)
            => Services.PdbSymbolStore(wf);

        public static PdbSvc PdbSvc(this IWfRuntime wf)
            => Services.PdbSvc(wf);

        public static PdbReader PdbReader(this IWfRuntime wf, in PdbSymbolSource src)
            => Z0.PdbReader.create(wf,src);
    }
}