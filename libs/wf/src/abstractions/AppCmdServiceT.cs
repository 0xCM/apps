//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [CmdProvider]
    public abstract class AppCmdService<T> : CmdService<T>, IAppCmdSvc
        where T : AppCmdService<T>, new()
    {
        protected virtual void PublishCommands()
        {

        }

        public static T create(IWfRuntime wf, params ICmdProvider[] src)
        {
            var service = new T();
            ApiGlobals.Instance.Inject(Cmd.dispatcher(service, wf.EventLog, src));
            service.Init(wf);
            service.PublishCommands();
            return service;
        }

        protected AppCmdService()
        {
            PromptTitle = "cmd";
        }

        public override IDispatcher Dispatcher => ApiGlobals.Instance.Injected<CmdDispatcher>();

        [CmdOp("jobs/run")]
        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
        }

        public virtual void RunJobs(string match)
        {
            var paths = AppDb.Service.Jobs().Files();
            var counter = 0u;
            for(var i=0; i<paths.Count; i++)
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
                Warn(string.Format("No jobs identified by '{0}'", match));
        }

        protected virtual string PromptTitle {get;}

        string Prompt()
            => string.Format("{0}> ", PromptTitle);

        ShellCmdSpec Next()
        {
            var input = term.prompt(Prompt());
            return ShellCmd.parse(input);
        }

        public virtual void Run()
        {
            var input = Next();
            while(input.Name != ".exit")
            {
                if(input.IsNonEmpty)
                    Dispatch(input);
                input = Next();
            }
        }
   }
}