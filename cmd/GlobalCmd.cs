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
                wf.MemCmd(),
                wf.ToolsetCmd(),
                wf.CaptureCmd(),
                wf.AsmCoreCmd(),
                wf.LlvmCmd(),
                wf.XedTool(),
                wf.Machines(),
                wf.ApiCmd(),
                wf.SourceSymbolic(),
                wf.IntelIntrinsicsCmd(),
                wf.AsmCmdSvc(),
                wf.XedCmd(),
                wf.XedChecks(),
                wf.CliCmd(),
                wf.ScriptCmd(),
                wf.RuntimeCmd(),
                wf.AsmChecks(),
                wf.CheckRunner()
                };

        public static AppCmd commands(IWfRuntime wf)
        {
            var xed = GlobalServices.Instance.Inject(wf.XedRuntime());
            return create(wf, providers(wf));
        }

        protected override void Initialized()
        {
            RunCmd("project", CmdArgs.create(new CmdArg[]{new CmdArg(EmptyString, "mc.models")}));
        }
    }
}