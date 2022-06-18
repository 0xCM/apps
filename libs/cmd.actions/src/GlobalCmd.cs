//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class GlobalCmd : AppCmdService<GlobalCmd>
    {
        public static GlobalCmd commands(IWfRuntime wf)
        {
            var xed = GlobalSvc.Instance.Inject(wf.XedRuntime());
            var providers = new ICmdProvider[]{
                wf.ProjectCmd(),
                wf.CaptureCmd(),
                wf.AsmCoreCmd(),
                wf.LlvmCmd(),
                wf.XedTool(),
                wf.Machines(),
                wf.ApiCmd(),
                wf.CheckCmd(),
                wf.AsmCmdProvider(),
                wf.IntelIntrinsicsCmd(),
                wf.AsmCmdSvc(),
                wf.XedCmd(),
                //wf.XedChecks(),
                //wf.AsmChecks()
                };

            foreach(var provider in providers)
            {
                foreach(var action in provider.Actions.Specs)
                {
                    term.babble($"{provider}:{action}");
                }
            }

            var dst = create(wf,providers);
            return dst;
        }

        protected override void Initialized()
        {
            RunCmd("project", new CmdArg[]{new CmdArg(EmptyString, "canonical")});
        }

        [CmdOp("jobs/run")]
        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
        }
    }
}