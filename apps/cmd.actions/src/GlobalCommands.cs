//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class GlobalCommands : AppCmdService<GlobalCommands,CmdShellState>
    {
        public GlobalCommands()
        {
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => array<ICmdProvider>(
                this,
                wf.XedCommands(),
                wf.ApiCommands(),
                wf.LlvmCommands(),
                wf.ProjectCommands(),
                wf.CodeGenCommands(),
                wf.CheckCommands()
                );

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
            if(args.Count == 0)
            {
                var paths = ProjectDb.JobSpecs();
                var count = paths.Length;
                if(count == 0)
                    Warn("No jobs defined");

                for(var i=0; i<count; i++)
                    DispatchJobs(paths[i]);
            }

            return result;
        }

        void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines();
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