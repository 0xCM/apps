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
            public AsmFlowCmd AsmFlowCmd(IWfRuntime wf)
                => Service<AsmFlowCmd>(wf);

            public XedToolCmd XedToolCmd(IWfRuntime wf)
                => Service<XedToolCmd>(wf);

            public NasmCatalog NasmCatalog(IWfRuntime wf)
                => Service<NasmCatalog>(wf);

            public CultProcessor CultProcessor(IWfRuntime wf)
                => Service<CultProcessor>(wf);

            public IApiSpecs ApiSpecsCmd(IWfRuntime wf)
                => Service<ApiSpecsCmd>(wf);

            public CodeCmd CodeCmd(IWfRuntime wf)
                => Service<CodeCmd>(wf);
        }

       static AppSvcCache Services => AppSvcCache.Instance;

        public static AsmFlowCmd AsmFlowCmd(this IWfRuntime wf)
           => Services.AsmFlowCmd(wf);

        public static IApiSpecs ApiSpecsCmd(this IWfRuntime wf)
            => Services.ApiSpecsCmd(wf);

        public static XedToolCmd XedToolCmd(this IWfRuntime wf)
            => Services.XedToolCmd(wf);

        public static CodeCmd CodeCmd(this IWfRuntime wf)
            => Services.CodeCmd(wf);

        public static NasmCatalog NasmCatalog(this IWfRuntime wf)
            => Services.NasmCatalog(wf);

        public static CultProcessor CultProcessor(this IWfRuntime wf)
            => Services.CultProcessor(wf);
    }
}