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
            => array<ICmdProvider>(this,
                wf.XedCommands(),
                wf.ApiCommands(),
                wf.LlvmCommands(),
                wf.ProjectCommands(),
                wf.CodeGenCommands()
                );

        IntelXed Xed => Service(Wf.IntelXed);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        [CmdOp("asm-gen-models")]
        protected Outcome GenAsmModels(CmdArgs args)
        {
            var dst = Service(Wf.Generators).CodeGenDir("asm.models");
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
    }
}