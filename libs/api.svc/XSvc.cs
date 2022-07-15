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

            public AsmFlowCmd AsmFlowCmd(IWfRuntime wf)
                => Service<AsmFlowCmd>(wf);

            public XedToolSvc XedTool(IWfRuntime wf)
                => Service<XedToolSvc>(wf);

            public NasmCatalog NasmCatalog(IWfRuntime wf)
                => Service<NasmCatalog>(wf);

            public Nasm Nasm(IWfRuntime wf)
                => Service<Nasm>(wf);

            public NDisasm NDisasm(IWfRuntime wf)
                => Service<NDisasm>(wf);

            public CultProcessor CultProcessor(IWfRuntime wf)
                => Service<CultProcessor>(wf);

            public IApiSpecs ApiSpecsCmd(IWfRuntime wf)
                => Service<ApiSpecsCmd>(wf);
        }


       static AppSvcCache Services => AppSvcCache.Instance;

        public static AsmFlowCmd AsmFlowCmd(this IWfRuntime wf)
            => Services.AsmFlowCmd(wf);

        public static IApiSpecs ApiSpecsCmd(this IWfRuntime wf)
            => Services.ApiSpecsCmd(wf);

        public static BdDisasm BdDisasm(this IWfRuntime wf)
            => Services.BdDisasm(wf);

        public static XedToolSvc XedTool(this IWfRuntime wf)
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