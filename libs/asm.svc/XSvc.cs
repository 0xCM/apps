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
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public ApiCapture ApiCapture(IWfRuntime wf)
                => Service<ApiCapture>(wf);

            public CaptureWfCmd CaptureCmd(IWfRuntime wf)
                => Service<CaptureWfCmd>(wf);

            public AsmCmdService AsmCmdSvc(IWfRuntime wf)
                => Service<AsmCmdService>(wf);

            public GenCmd GenCmd(IWfRuntime wf)
                => Service<GenCmd>(wf);

            public CaptureWf CaptureWf(IWfRuntime wf)
                => Service<CaptureWf>(wf);

            public AsmDbCmd AsmDbCmd(IWfRuntime wf)
                => Service<AsmDbCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static GenCmd GenCmd(this IWfRuntime wf)
            => Services.GenCmd(wf);

        public static ApiCapture ApiCapture(this IWfRuntime wf)
            => Services.ApiCapture(wf);

        public static AsmCmdService AsmCmdSvc(this IWfRuntime wf)
            => Services.AsmCmdSvc(wf);

        public static CaptureWfCmd CaptureCmd(this IWfRuntime wf)
            => Services.CaptureCmd(wf);

        public static CaptureWf CaptureWf(this IWfRuntime wf)
            => Services.CaptureWf(wf);

        public static AsmDbCmd AsmDbCmd(this IWfRuntime wf)
            => Services.AsmDbCmd(wf);
    }
}