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

            public ImmSpecializer ImmSpecializer(IWfRuntime wf)
                => Service<ImmSpecializer>(wf);

            public CaptureCmd CaptureCmd(IWfRuntime wf)
                => Service<CaptureCmd>(wf);

            public ApiImmEmitter ImmEmitter(IWfRuntime wf)
                => Service<ApiImmEmitter>(wf);


            public AsmCmdService AsmCmdSvc(IWfRuntime wf)
                => Service<AsmCmdService>(wf);

        }

        static Svc Services => Svc.Instance;


    }
}