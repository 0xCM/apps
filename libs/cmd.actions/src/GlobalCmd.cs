//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;

    public partial class GlobalCmd : AppCmdService<GlobalCmd,CmdShellState>, ICmdRunner
    {
        public static GlobalCmd commands(IWfRuntime wf)
        {
            var svc = new GlobalCmd();
            var xed = XedRuntime.create(wf).Inject();
            var providers = array<ICmdProvider>(
                svc,
                ProjectCmd.inject(svc, ProjectCmd.create(wf)),
                AsmCoreCmd.commands(wf),
                LlvmCmdProvider.create(wf),
                wf.PolyBits(),
                wf.XedTool(),
                wf.DiagnosticCmd(),
                wf.Machines(),
                wf.ApiCmd(),
                wf.CheckCmd(),
                wf.AsmCmd(),
                XedCmd.commands(xed)
                );

            return GlobalCmd.init(wf, svc, providers);
        }

        static ICmdProvider[] _Providers;

        public static GlobalCmd init(IWfRuntime wf, GlobalCmd svc, ICmdProvider[] providers)
        {
            _Providers = providers;
            svc.Init(wf);
            return svc;
        }

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Error(result.Message);
        }

        public void RunCmd(string name, CmdArgs args)
        {
            Dispatcher.Dispatch(name, args);
        }

        protected override void Initialized()
        {
            var args = new CmdArg[]{new CmdArg(EmptyString, "canonical")};
            RunCmd("project", args);
        }

        public void runJobs(string match)
        {
            var paths = ProjectDb.JobSpecs();
            var count = paths.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref paths[i];
                if(path.FileName.Format().StartsWith(match))
                {
                    var dispatching = Running(string.Format("Dispatching job {0} defined by {1}", counter, path.ToUri()));
                    _dispatchJobs(path);
                    Ran(dispatching, string.Format("Dispatched job {0}", counter));
                    counter++;
                }
            }

            if(counter == 0)
                Warn(string.Format("No jobs identified by '{0}'", match));
        }

        public void RunJobs(string match)
            => runJobs(match);

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => _Providers;

        [CmdOp("jobs/run")]
        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
        }

        public void _dispatchJobs( FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(Cmd.cmdspec(lines[i].Content));
        }

        void DispatchJobs(FS.FilePath src)
            => _dispatchJobs(src);

    }
}