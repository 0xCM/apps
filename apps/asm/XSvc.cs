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
            public AsmEtl AsmEtl(IWfRuntime wf)
                => Service<AsmEtl>(wf);

            public AsmDecoder AsmDecoder(IWfRuntime wf)
                => Service<AsmDecoder>(wf);

            public ApiExtractor ApiExtractor(IWfRuntime wf)
                => Service<ApiExtractor>(wf);

            public ApiExtractWorkflow ApiExtractWorkflow(IWfRuntime wf)
                => Service<ApiExtractWorkflow>(wf);

            public HostAsmEmitter HostAsmEmitter(IWfRuntime wf)
                => Service<HostAsmEmitter>(wf);

            public ApiCapture ApiCapture(IWfRuntime wf)
                => Service<ApiCapture>(wf);

            public AsmCallPipe AsmCallPipe(IWfRuntime wf)
                => Service<AsmCallPipe>(wf);

            public ProcessAsmSvc ProcessAsm(IWfRuntime wf)
                => Service<ProcessAsmSvc>(wf);

            public AsmJmpPipe AsmJmpPipe(IWfRuntime wf)
                => Service<AsmJmpPipe>(wf);

            public AsmRowBuilder AsmRowBuilder(IWfRuntime wf)
                => Service<AsmRowBuilder>(wf);

            public AsmAnalyzer AsmAnalyzer(IWfRuntime wf)
                => Service<AsmAnalyzer>(wf);
        }

        static Svc Services => Svc.Instance;

        public static AsmEtl AsmEtl(this IWfRuntime wf)
            => Services.AsmEtl(wf);

        public static ApiExtractor ApiExtractor(this IWfRuntime wf)
            => Services.ApiExtractor(wf);

        public static ApiExtractWorkflow ApiExtractWorkflow(this IWfRuntime wf)
            => Services.ApiExtractWorkflow(wf);

        public static AsmRowBuilder AsmRowBuilder(this IWfRuntime wf)
            => Services.AsmRowBuilder(wf);

        public static HostAsmEmitter HostAsmEmitter(this IWfRuntime wf)
            => Services.HostAsmEmitter(wf);

        public static ApiCapture ApiCapture2(this IWfRuntime wf)
            => Services.ApiCapture(wf);

        public static AsmJmpPipe AsmJmpPipe(this IWfRuntime wf)
            => Services.AsmJmpPipe(wf);

        public static AsmDecoder AsmDecoder(this IWfRuntime wf)
            => Services.AsmDecoder(wf);

        public static ProcessAsmSvc ProcessAsmSvc(this IWfRuntime wf)
            => Services.ProcessAsm(wf);

        public static AsmCallPipe AsmCallPipe(this IWfRuntime wf)
            => Services.AsmCallPipe(wf);

        public static AsmAnalyzer AsmAnalyzer(this IWfRuntime wf)
            => Services.AsmAnalyzer(wf);


        [Op]
        public static ApiCaptureService ApiCapture(this IWfRuntime wf)
            => Z0.ApiCaptureService.create(wf);

        [Op]
        public static ApiCaptureRunner CaptureRunner(this IWfRuntime wf)
            => ApiCaptureRunner.create(wf);

        [Op]
        public static ApiImmEmitter ImmEmitter(this IWfRuntime wf)
            => ApiImmEmitter.create(wf);

        [Op]
        public static AsmStatementProducer AsmStatementProducer(this IWfRuntime wf)
            => Asm.AsmStatementProducer.create(wf);

        [Op]
        public static ApiCaptureEmitter CaptureEmitter(this IWfRuntime wf)
            => ApiCaptureEmitter.create(wf);

        [Op]
        public static ICaptureCore CaptureCore(this IWfRuntime wf)
            => Asm.CaptureCore.create(wf);

        [Op]
        public static ImmSpecializer ImmSpecializer(this IWfRuntime wf)
            => Z0.Asm.ImmSpecializer.create(wf);

    }
}