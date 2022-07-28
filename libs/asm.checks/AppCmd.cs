//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    unsafe class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.AsmCmdSvc(),
                wf.ProjectCmd(),
                wf.WfCmd(),
                wf.MemCmd(),
                wf.ToolBoxCmd(),
                wf.CaptureCmd(),
                wf.AsmCoreCmd(),
                wf.LlvmCmd(),
                wf.Machines(),
                wf.SourceSymbolic(),
                wf.IntelInxCmd(),
                wf.AsmCmdSvc(),
                wf.XedCmd(),
                wf.XedChecks(),
                wf.AsmChecks()
            };

        public static AppCmd commands(IWfRuntime wf)
            => create(wf, providers(wf));
    }
}