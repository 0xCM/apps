//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public CheckCmd CheckCmd(IWfRuntime wf)
                => Service<CheckCmd>(wf);

            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

            public CaptureCmd CaptureCmd(IWfRuntime wf)
                => Service<CaptureCmd>(wf);

            public ProjectCmd ProjectCmd(IWfRuntime wf)
                => Service<ProjectCmd>(wf);

            public AsmFlowCommands AsmFlows(IWfRuntime wf)
                => Service<AsmFlowCommands>(wf);

            public AsmCmdService AsmCmdSvc(IWfRuntime wf)
                => Service<AsmCmdService>(wf);
        }

        static Svc Services = Svc.Instance;

       public static AsmFlowCommands AsmFlows(this IWfRuntime wf)
            => Services.AsmFlows(wf);

        public static CheckCmd CheckCmd(this IWfRuntime wf)
            => Services.CheckCmd(wf);

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

       public static AsmCmdService AsmCmdSvc(this IWfRuntime wf)
            => Services.AsmCmdSvc(wf);

        public static CaptureCmd CaptureCmd(this IWfRuntime wf)
            => Services.CaptureCmd(wf);

        public static ProjectCmd ProjectCmd(this IWfRuntime wf)
            => Services.ProjectCmd(wf);
    }
}