//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    [CmdProvider]
    public abstract class AppCmdService<T> : CmdService<T>, IAppCmdService
        where T : AppCmdService<T>, new()
    {
        protected CmdLineRunner CmdLines => Wf.CmdLines();

        protected virtual void PublishCommands()
        {

        }

        public static T create(IWfRuntime wf, params ICmdProvider[] src)
        {
            var service = new T();
            GlobalServices.Instance.Inject(Cmd.dispatcher(service, wf.EventLog, src));
            service.Init(wf);
            service.PublishCommands();
            return service;
        }

        protected AppCmdService()
        {
            PromptTitle = "cmd";
        }

        public override IDispatcher Dispatcher => GlobalServices.Instance.Injected<CmdDispatcher>();

        protected OmniScript OmniScript => Wf.OmniScript();

        [CmdOp("jobs/run")]
        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
        }

        [CmdOp("cmd")]
        protected void RunCmd(CmdArgs args)
        {
            var count = Demand.gt(args.Count,0u);
            var spec = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    spec.Append(Chars.Space);
                spec.Append(args[i].Value);
            }

            var cmd = Cmd.cmd(spec.Emit());
            Status($"Executing '{cmd}'");
            CmdLines.Start(cmd);
        }

        [CmdOp("pwsh")]
        protected void RunPwshCmd(CmdArgs args)
        {
            var cmd = Cmd.pwsh(Cmd.join(args));
            Status($"Executing '{cmd}'");
            CmdLines.Start(cmd);
        }

        [CmdOp("control/launchers")]
        protected void Launchers(CmdArgs args)
        {
            var src = AppDb.Control().Sources("launch").Files(FileKind.Ps1);
            iter(src, file => Write(file.FileName.WithoutExtension));
        }


        [CmdOp("control/launch")]
        protected void LaunchTargets(CmdArgs args)
        {
            var scripts = args.Map(x => AppDb.Control().Sources("launch").Path(FS.file(x.Value, FileKind.Ps1)));
            iter(scripts, script => {
                Status($"Launching target defined by {script.ToUri()}", FlairKind.Running);
                var cmd = Scripts.pwsh(script);
                CmdLines.Start(cmd);
                Status($"Launch script {script.ToUri()} executing", FlairKind.Ran);
            });
        }


        [CmdOp("files")]
        protected void ListFiles(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            var files = FS.listing(src);
            iter(files, file => Write(file.Path));
            TableEmit(files, AppDb.App().Table<ListedFile>());
        }

        public virtual void RunJobs(string match)
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