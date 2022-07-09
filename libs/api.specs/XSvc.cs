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
            public BdDisasm BdDisasm(IWfRuntime wf)
                => Service<BdDisasm>(wf);


            public DumpBin DumpBin(IWfRuntime wf)
                => Service<DumpBin>(wf);


            public AsmFlowCommands AsmFlows(IWfRuntime wf)
                => Service<AsmFlowCommands>(wf);


            public XedTool XedTool(IWfRuntime wf)
                => Service<XedTool>(wf);

            public NasmCatalog NasmCatalog(IWfRuntime wf)
                => Service<NasmCatalog>(wf);

            public Nasm Nasm(IWfRuntime wf)
                => Service<Nasm>(wf);

            public NDisasm NDisasm(IWfRuntime wf)
                => Service<NDisasm>(wf);

            public CultProcessor CultProcessor(IWfRuntime wf)
                => Service<CultProcessor>(wf);

            public IApiSpecs ApiSpecs(IWfRuntime wf)
                => Service<ApiSpecs>(wf);
        }


       static AppSvcCache Services => AppSvcCache.Instance;

        public static AsmFlowCommands AsmFlows(this IWfRuntime wf)
            => Services.AsmFlows(wf);

        public static IApiSpecs ApiSpecs(this IWfRuntime wf)
            => Services.ApiSpecs(wf);

        public static BdDisasm BdDisasm(this IWfRuntime wf)
            => Services.BdDisasm(wf);

        public static XedTool XedTool(this IWfRuntime wf)
            => Services.XedTool(wf);

        public static DumpBin DumpBin(this IWfRuntime wf)
            => Services.DumpBin(wf);


        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Services.NasmCatalog(wf);

        public static Nasm Nasm(this IWfRuntime wf)
            => Services.Nasm(wf);

        public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Services.CultProcessor(wf);

        public static NDisasm NDisasm(this IWfRuntime wf)
            => Services.NDisasm(wf);


    }
}