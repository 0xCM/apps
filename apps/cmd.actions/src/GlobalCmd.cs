//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class GlobalCmd : AppCmdService<GlobalCmd,CmdShellState>, ICmdRunner
    {
        static ICmdProvider[] _Providers;

        public static GlobalCmd init(IWfRuntime wf, GlobalCmd svc, AsmCmdRt asmrt, ICmdProvider[] providers)
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

        [CmdOp("capture")]
        Outcome CaptureV1(CmdArgs args)
        {
            var result = Capture.run();
            return true;
        }

        [CmdOp("capture-v2")]
        Outcome CaptureV2(CmdArgs args)
        {
           Wf.ApiExtractWorkflow().Run(args);
           return true;
        }

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

        [CmdOp(".commands")]
        Outcome EmitShellCommands(CmdArgs args)
        {
            return EmitShellCommands(Dispatcher);
        }

        Outcome EmitShellCommands(ICmdDispatcher dispatcher)
        {
            var dst = ProjectDb.Api() + FS.file($"api.commands.{GetType().Name.ToLower()}", FS.Csv);
            return EmitCommands(dispatcher, dst);
        }

        Outcome EmitCommands(ICmdDispatcher dispatcher, FS.FilePath dst)
        {
            iter(dispatcher.SupportedActions, cmd => Write(cmd));
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            iter(dispatcher.SupportedActions, cmd => writer.WriteLine(cmd));
            EmittedFile(emitting, dispatcher.SupportedActions.Length);
            return true;
        }
    }
}