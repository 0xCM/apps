//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;
    using static ApiGranules;

    using static core;

    [CmdProvider]
    public abstract class AppCmdService<T> : WfSvc<T>, IAppCmdService, ICmdProvider, ICmdRunner
        where T : AppCmdService<T>, new()
    {
        public static T create(IWfRuntime wf, params ICmdProvider[] src)
        {
            var dst = new T();
            var actions = bag<CmdActions>();
            actions.Add(CmdActions.discover(dst));
            iter(src, x => actions.Add(x.Actions));
            var dispatcher = CmdActions.dispatcher(CmdActions.join(actions.ToArray()));
            GlobalSvc.Instance.Inject(dispatcher);
            dst.Init(wf);
            return dst;
        }

        protected AppCmdService()
        {
            _Context = new();
            PromptTitle = "cmd";
            Actions = CmdActions.discover((T)this);
        }

        public CmdActions Actions {get;}

        public ICmdDispatcher Dispatcher => GlobalSvc.Instance.Injected<CmdActionDispatcher>();

        public WsCatalog ProjectFiles {get; private set;}

        IWsProject _Project;

        ConcurrentDictionary<ProjectId,WsContext> _Context = new();

        IWorkerLog Witness;

        Option<IToolCmdShell> Shell;

        protected ICmdRunner Commands;

        void Project(IWsProject ws)
        {
            _Project = Require.notnull(ws);
            ProjectFiles = WsCatalog.load(ws);
        }

        [CmdOp("project")]
        public void LoadProject(CmdArgs args)
            => LoadProjectSources(AppDb.LlvmModel(arg(args,0).Value));

        bool LoadProjectSources(IWsProject ws)
        {
            if(ws == null)
            {
                Error("Project unspecified");
                return false;
            }

            Status($"Loading project from {ws.Home()}");

            Project(ws);

            var dir = ws.Home();
            if(dir.Exists)
                Files(ws.SrcFiles());
            return true;
        }

        protected void LoadProject(IWsProject src)
        {
            if(src == null)
            {
                Error("Project unspecified");
                return;
            }

            var outcome = Outcome.Success;
            var dir = src.Home();
            outcome = dir.Exists;
            if(outcome)
                Files(src.SrcFiles());
            else
                outcome = (false, Msg.ProjectUndefined.Format(src.Project));
        }

        [CmdOp("project/home")]
        protected void ProjectHome()
            => Write(Context().Project.Home());

        [CmdOp("project/files")]
        protected void ListProjectFiles(CmdArgs args)
        {
            if(args.Count != 0)
                iter(Context().Catalog.Entries(arg(args,0)), file => Write(file.Format()));
            else
                iter(Context().Catalog.Entries(), file => Write(file.Format()));
        }

        protected void ProjectLoad(string name)
            => Dispatcher?.Dispatch("project", new CmdArg[]{new CmdArg(EmptyString, name)});

        [MethodImpl(Inline)]
        public IWsProject Project()
            => _Project;

        protected WsContext Context()
        {
            var project = Project();
            return _Context.GetOrAdd(project.Id, _ => WsContext.load(project));
        }

        protected override void OnInit()
        {
            Witness = Loggers.worker(controller().Id(), ProjectDb.Home(), typeof(T).Name);
        }

        protected OmniScript OmniScript => Wf.OmniScript();

        protected AppSvcOps AppSvc => Wf.AppSvc();

        protected ToolWs ToolWs => new ToolWs(AppDb.Toolbase());

        [CmdOp("settings")]
        protected void AppSetings()
        {
            var src = AppDb.Settings();
            iter(src, setting => Write(setting.Format()));
        }

        [CmdOp("commands")]
        protected void EmitCommands()
            => EmitCommands(AppDb.ApiTargets().Path(FS.file($"{controller().Id().Format()}.commands", FS.Csv)));


        [CmdOp("env/load")]
        protected Outcome LoadEnv(CmdArgs args)
        {
            var name = Environment.MachineName.ToLower();
            if(args.Count != 0)
                name = arg(args,0).Value.Format();

            var set = AppDb.LoadEnv(name).Vars;
            iter(set, member => Write(member.Format()));

            return true;
        }

        [CmdOp("env/emit")]
        protected void EmitEnvVars()
        {
            TableEmit(EnvDb.records(Environs.vars(), machine), AppDb.Env().Table<EnvSetting>(machine));
        }

        protected Settings UpdateToolEnv()
        {
            var path = ToolWs.Service.Toolbase.Path(FS.file("show-env-config", FS.Cmd));
            var cmd = CmdScript.cmdline(path.Format(PathSeparator.BS));
            return AppSettings.Load(OmniScript.RunCmd(cmd));
        }

        protected Settings LoadToolEnv(string name)
        {
            var path = ToolWs.Service.Toolbase.Path(FS.file(name, FileKind.Env));
            return AppSettings.Load(path.ReadNumberedLines());
        }

        [CmdOp("tools/env")]
        protected Outcome ShowToolEnv(CmdArgs args)
        {
            var settings = LoadToolEnv(tools);
            iter(settings, s => Write(s));
            return true;
        }

        [CmdOp("tools/script")]
        protected Outcome ToolScript(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var script = ToolWs.Script(tool, arg(args,1).Value);
            if(!script.Exists)
                return (false, FS.missing(script));
            else
                return OmniScript.Run(script, out var _);
        }

        [CmdOp("tools/config")]
        protected Outcome ConfigureTool(CmdArgs args)
        {
            var result = Outcome.Success;
            ToolId tool = arg(args,0).Value;
            var script = ToolWs.Service.ConfigScript(tool);
            result = OmniScript.Run(script, out var _);
            var logpath = ToolWs.ConfigLog(tool);
            using var reader = logpath.AsciLineReader();
            var line = AsciLine.Empty;
            while(reader.Next(out line))
            {
                Write(line.Format());
            }

            return result;
        }

        [CmdOp("tools/help")]
        protected void ShowToolHelp(CmdArgs args)
        {
            var result = Outcome.Success;
            var tool = (ToolId)arg(args,0).Value;
            var docs = ToolWs.Service.ToolDocs(tool);
            var doc = docs + FS.file(tool.Format(),FS.Help);
            if(doc.Exists)
            {
                using var reader = doc.Utf8LineReader();
                while(reader.Next(out var line))
                    Write(line.Content);
            }
        }

        [CmdOp("tools/settings")]
        protected Outcome ShowToolSettings(CmdArgs args)
        {
            var src = ToolWs.Service.Logs(arg(args,0).Value) + FS.file("config", FS.Log);
            if(!src.Exists)
                return (false,FS.missing(src));
            iter(ToolWs.settings(src), setting => Write(setting));
            return true;
        }

        [CmdOp("tools/docs")]
        protected Outcome ToolDocs(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var path = FS.FilePath.Empty;
            if(args.Length > 1)
                path = ToolWs.Service.ToolDocs(tool) + FS.file(arg(args,1));
            else
                path = ToolWs.Service.ToolDocs(tool) + FS.file(tool.Format(), FS.Help);

            if(path.Exists)
            {
                Write(path.ReadText());
                return true;
            }
            else
                return (false, FS.missing(path));
        }

        [CmdOp("runtime/cpucore")]
        protected Outcome ShowCurrentCore(CmdArgs args)
        {
            Write(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));
            return true;
        }

        public void RunCmd(string name)
        {
            var result = Dispatcher.Dispatch(name);
            if(result.Fail)
                Error(result.Message);
        }

        public void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        public void DispatchJobs(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines(true);
            var count = lines.Count;
            for(var i=0; i<count; i++)
                Dispatch(CmdSpecs.from(lines[i].Content));
        }

        [CmdOp("jobs/run")]
        Outcome RunJobs(CmdArgs args)
        {
            var result = Outcome.Success;
            RunJobs(arg(args,0));
            return result;
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

        void EmitCommands(FS.FilePath dst)
        {
            var actions = Dispatcher.SupportedActions.Index().Sort();
            var emitter = text.emitter();
            iter(Dispatcher.SupportedActions, cmd => emitter.AppendLine(cmd));
            FileEmit(emitter.Emit(), actions.Count, dst);
        }

        protected void DisplayCmdResponse(ReadOnlySpan<string> src)
        {
            for(var i=0; i<src.Length; i++)
            {
                if(CmdResponse.parse(skip(src,i), out CmdResponse response))
                    Write(response);
            }
        }

        protected static CmdArg arg(in CmdArgs src, int index)
            => CmdScript.arg(src, index);

        Outcome SelectTool(ToolId tool)
        {
            var result = Outcome.Success;
            if(Shell.IsNone())
            {
                result = (false, "Target shell unspecified");
                return result;
            }

            return Shell.Value.SelectTool(tool);
        }

        protected override void Disposing()
        {
            base.Disposing();
            Witness?.Dispose();
        }

        protected virtual string PromptTitle {get;}

        string Prompt()
            => string.Format("{0}> ", PromptTitle);

        CmdSpec Next()
        {
            var input = term.prompt(Prompt());
            return CmdSpecs.from(input);
        }

        public virtual void Run()
        {
            var input = Next();
            while(input.Name != ".exit")
            {
                if(input.IsNonEmpty)
                {
                    if(input.Name == ".tool")
                    {
                        var result = SelectTool(arg(input.Args,0).Value);
                        if(result.Fail)
                            Error(result.Message);
                    }
                    else
                    {
                        Witness.LogStatus(string.Format("{0} {1}", Prompt(), input.Format()));
                        Dispatch(input);
                    }
                }

                input = Next();
            }
        }

        public bool Dispatch(CmdSpec cmd)
        {
            var result = Outcome.Success;
            try
            {
                result = Dispatcher.Dispatch(cmd.Name, cmd.Args);
                if(result.Fail)
                    Error(result.Message ?? RP.Null);
                else
                {
                    if(nonempty(result.Message))
                        Status(result.Message);
                }
            }
            catch(Exception e)
            {
                Error(e);
                result = e;
            }
            return result;
        }
    }
}