//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class GlobalCommands : AppCmdService<GlobalCommands,CmdShellState>, ICmdRunner
    {
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

        public GlobalCommands()
        {
        }

        public void RunCmd(string name)
        {
            Dispatcher.Dispatch(name);
        }

        public void RunCmd(string name, CmdArgs args)
        {
            Dispatcher.Dispatch(name, args);
        }

        public void RunJobs(string match)
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
                    DispatchJobs(path);
                    Ran(dispatching, string.Format("Dispatched job {0}", counter));
                    counter++;
                }
            }

            if(counter == 0)
            {
                Warn(string.Format("No jobs identified by '{0}'", match));
            }
        }

        static ProjectCmdProvider inject(ICmdRunner src, ProjectCmdProvider dst)
            => dst.With(src);

        static AsmCmdProvider inject(IProjectProvider src, AsmCmdProvider dst)
            => dst.With(src);

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
        {
            var projects = inject((ICmdRunner)this, wf.ProjectCommands());
            return array<ICmdProvider>(
                this,
                projects,
                wf.XedCommands(),
                wf.ApiCommands(),
                wf.LlvmCommands(),
                wf.CodeGenCommands(),
                wf.CheckCommands(),
                inject(projects,wf.AsmCommands())
                );
        }

        IntelXed Xed => Service(Wf.IntelXed);

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
            // var paths = ProjectDb.JobSpecs();
            // var count = paths.Length;
            // if(args.Count == 0)
            // {
            //     if(count == 0)
            //         Warn("No jobs defined");

            //     for(var i=0; i<count; i++)
            //         DispatchJobs(paths[i]);
            // }
            // else
            // {
            //     var counter = 0u;
            //     var match = arg(args,0).Value.Format();
            //     for(var i=0; i<count; i++)
            //     {
            //         ref readonly var path = ref paths[i];
            //         if(path.FileName.Format().StartsWith(match))
            //         {
            //             var dispatching = Running(string.Format("Dispatching job {0} defined by {1}", counter, path.ToUri()));
            //             DispatchJobs(path);
            //             Ran(dispatching, string.Format("Dispatched job {0}", counter));
            //             counter++;
            //         }
            //     }

            //     if(counter == 0)
            //     {
            //         Warn(string.Format("No jobs identified by '{0}'", match));
            //     }

            // }

            return result;
        }

        void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(Cmd.cmdspec(lines[i].Content));
        }

        [CmdOp(".commands")]
        Outcome EmitShellCommands(CmdArgs args)
        {
            return EmitShellCommands(Dispatcher);
        }

        Outcome EmitShellCommands(ICmdDispatcher dispatcher)
        {
            var dst = ProjectDb.Api() + FS.file("api.shell.commands", FS.Csv);
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