//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

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

        public static void dispatch(ReadOnlySpan<string> args)
        {
            try
            {
                var count = args.Length;
                var paths = EnvPaths.create();
                var handlers = paths.ResultHandlers();

                for(var i=0; i<count; i++)
                {
                    var name = FS.file(args[i]);
                    term.inform(name);

                    if(!name.HasExtension)
                        name = name.WithExtension(FS.Cmd);

                    var script = paths.ControlScript(name);
                    if(script.Exists)
                    {
                        var runner = paths.ScriptRunner();
                        var output = runner.RunControlScript(name);
                        var processor = CmdResultProcessor.create(script, handlers);
                        term.inform("Response");
                        iter(output, x => processor.Process(x));
                    }
                    else
                    {
                        term.error($"The script {script.ToUri()} does not exist");
                    }
                }
            }
            catch(Exception e)
            {
                term.error(e);
            }
        }

        public GlobalCmd()
        {
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
        {
            return _Providers;
            // var asmrt = AsmCmdRt.runtime(wf, false);
            // var cmd = wf.ProjectCommands();
            // ProjectCmd.inject(asmrt, cmd);
            // var projects = ProjectCmd.inject((ICmdRunner)this, cmd);
            // return array<ICmdProvider>(
            //     this,
            //     projects,
            //     asmrt.Commands,
            //     wf.PbCmd(),
            //     wf.ApiCommands(),
            //     wf.LlvmCommands(),
            //     wf.CheckCommands(),
            //     wf.AsmCommands()
            //     );
        }

        [CmdOp("asm-gen-models")]
        protected Outcome GenAsmModels(CmdArgs args)
        {
            var dst = Service(Wf.CodeGen).CodeGenDir("asm.models");
            return true;
        }

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