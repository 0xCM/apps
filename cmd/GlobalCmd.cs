//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class AppCmd : AppCmdService<AppCmd>
    {
        public static ICmdProvider[] providers(IWfRuntime wf)
            => new ICmdProvider[]{
                wf.ProjectCmd(),
                wf.EnvCmd(),
                wf.DbCmd(),
                wf.ToolsetCmd(),
                wf.CaptureCmd(),
                wf.AsmCoreCmd(),
                wf.LlvmCmd(),
                wf.XedTool(),
                wf.Machines(),
                wf.ApiCmd(),
                wf.SourceSymbolic(),
                wf.AsmCmdProvider(),
                wf.IntelIntrinsicsCmd(),
                wf.AsmCmdSvc(),
                wf.XedCmd(),
                wf.XedChecks(),
                wf.AsmChecks()
                };


        public static AppCmd commands(IWfRuntime wf)
        {
            var xed = GlobalSvc.Instance.Inject(wf.XedRuntime());
            return create(wf, providers(wf));
        }

        protected override void Initialized()
        {
            RunCmd("project", new CmdArg[]{new CmdArg(EmptyString, "canonical")});
        }
    }
}