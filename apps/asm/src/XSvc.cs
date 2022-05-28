//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [ApiHost]
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public AsmDecoder AsmDecoder(IWfRuntime wf)
                => Service<AsmDecoder>(wf);

            public ApiExtractor ApiExtractor(IWfRuntime wf)
                => Service<ApiExtractor>(wf);

            public ApiExtractWorkflow ApiExtractWorkflow(IWfRuntime wf)
                => Service<ApiExtractWorkflow>(wf);

            public HostAsmEmitter HostAsmEmitter(IWfRuntime wf)
                => Service<HostAsmEmitter>(wf);

        }

        static Svc Services => Svc.Instance;

        public static AsmEtl AsmEtl(this IWfRuntime context)
            => Asm.AsmEtl.create(context);

        public static ApiExtractor ApiExtractor(this IWfRuntime wf)
            => Services.ApiExtractor(wf);

        public static ApiExtractWorkflow ApiExtractWorkflow(this IWfRuntime wf)
            => Services.ApiExtractWorkflow(wf);

        public static AsmRowBuilder AsmRowBuilder(this IWfRuntime wf)
            => Asm.AsmRowBuilder.create(wf);

        public static HostAsmEmitter HostAsmEmitter(this IWfRuntime wf)
            => Services.HostAsmEmitter(wf);

        public static AsmJmpPipe AsmJmpPipe(this IWfRuntime wf)
            => Asm.AsmJmpPipe.create(wf);

        public static AsmDecoder AsmDecoder(this IWfRuntime wf)
            => Services.AsmDecoder(wf);

        public static ProcessAsmSvc ProcessAsmSvc(this IWfRuntime wf)
            => Asm.ProcessAsmSvc.create(wf);

        public static AsmCallPipe AsmCallPipe(this IWfRuntime wf)
            => Asm.AsmCallPipe.create(wf);

        public static AsmAnalyzer AsmAnalyzer(this IWfRuntime wf)
            => Z0.AsmAnalyzer.create(wf);
    }
}