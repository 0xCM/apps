//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class GlobalCmd : AppCmdService<GlobalCmd,CmdShellState>
    {
        public static GlobalCmd commands(IWfRuntime wf)
        {
            var runner = new GlobalCmd();
            var xed = GlobalSvc.Instance.Inject(wf.XedRuntime());
            var providers = array<ICmdProvider>(
                runner,
                wf.ProjectCmd(runner),
                wf.CaptureCmd(),
                wf.AsmCoreCmd(),
                wf.LlvmCmd(),
                wf.PolyBits(),
                wf.XedTool(),
                wf.DiagnosticCmd(),
                wf.Machines(),
                wf.ApiCmd(),
                wf.CheckCmd(),
                wf.AsmCmd(),
                wf.AsmChecks(),
                wf.IntelIntrinsicsCmd(),
                xed.XedCmd(),
                xed.XedChecks()
                );

            _Providers = providers;
            runner.Init(wf);
            return runner;
        }

        static ICmdProvider[] _Providers;

        protected override void Initialized()
        {
            RunCmd("project", new CmdArg[]{new CmdArg(EmptyString, "canonical")});
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => _Providers;

        [CmdOp("jobs/run")]
        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
        }
    }
}