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
                wf.ApiCmd(),
                wf.AncestryChecks(),
                wf.AsmCoreCmd(),
                wf.AsmCmdSvc(),
                wf.AsmChecks(),
                wf.CaptureCmd(),
                wf.CheckRunner(),
                wf.CliCmd(),
                wf.DbCmd(),
                wf.LlvmCmd(),
                wf.RoslynCmd(),
                wf.IntelInxCmd(),
                wf.MemCmd(),
                wf.Machines(),
                wf.ProjectCmd(),
                wf.RuntimeCmd(),
                wf.SqlDbCmd(),
                wf.ToolBoxCmd(),
                wf.WfCmd(),
                wf.WsDbCmd(),
                wf.XedCmd(),
                wf.XedChecks(),
                wf.BuildCmd(),
                wf.XedToolCmd(),
                wf.FsmCmd(),
                wf.CalcChecker(),
                wf.TestCmd(),
                wf.GenCmd(),
                };

        public static AppCmd commands(IWfRuntime wf)
        {
            var xed = ApiGlobals.Instance.Inject(wf.XedRuntime());
            return create(wf, providers(wf));
        }

        protected override void Initialized()
        {
            RunCmd("project", CmdArgs.create(new CmdArg[]{new CmdArg(EmptyString, "mc.models")}));
        }
    }
}