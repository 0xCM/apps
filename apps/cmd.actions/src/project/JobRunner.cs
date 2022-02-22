//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using static core;

    public class JobRunner : CmdDispatcher<JobRunner>
    {
        public void RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            var paths = ProjectDb.JobSpecs();
            var count = paths.Length;
            if(args.Count == 0)
            {
                if(count == 0)
                    Warn("No jobs defined");

                for(var i=0; i<count; i++)
                    DispatchJobs(paths[i]);
            }
            else
            {
                var counter = 0u;
                var match = arg(args,0).Value.Format();
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
        }

        void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(Cmd.cmdspec(lines[i].Content));
        }

        protected override ICmdProvider[] CmdProviders(IWfRuntime wf)
            => array<ICmdProvider>(
                wf.XedCommands(),
                wf.ApiCommands(),
                wf.LlvmCommands(),
                wf.ProjectCommands(),
                wf.CodeGenCommands(),
                wf.CheckCommands(),
                wf.AsmCommands()
                );
    }
}