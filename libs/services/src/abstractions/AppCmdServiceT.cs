//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static core;

    [CmdProvider]
    public abstract class AppCmdService<T> : WfSvc<T>, IAppCmdService, ICmdProvider, ICmdRunner
        where T : AppCmdService<T>, new()
    {
        public ICmdDispatcher Dispatcher {get; protected set;}

        IWorkerLog Witness;

        Option<IToolCmdShell> Shell;

        protected ICmdRunner Commands;

        protected AppCmdService()
        {
            PromptTitle = "cmd";
            CommonState = new CmdShellState();
        }

        public T With(ICmdRunner runner)
        {
            Commands = runner;
            return (T)this;
        }

        protected OmniScript OmniScript => Wf.OmniScript();

        protected AppSvcOps AppSvc => Wf.AppSvc();

        protected ToolWs ToolWs => new ToolWs(AppData.ToolBase);

        protected virtual ICmdProvider[] CmdProviders(IWfRuntime wf)
            => array(this);

        protected Index<ICmdProvider> Providers;

        public static T create(IWfRuntime wf, Index<ICmdProvider> providers)
        {
            var svc = new T();
            svc.Providers = providers + array((ICmdProvider)svc);
            svc.Dispatcher = CmdActions.dispatcher(svc.Providers, (cmd,args) => (false, string.Format("Handler for '{0}' not found", cmd)));
            svc.Init(wf);
            return svc;
        }

        protected override void OnInit()
        {
            if(Dispatcher == null)
                Dispatcher = CmdActions.dispatcher(CmdProviders(Wf), DispatchFallback);
            Witness = Loggers.worker(controller().Id(), ProjectDb.Home(), typeof(T).Name);
            CommonState.Init(Wf,Ws);
        }

        [CmdOp("ws/archives")]
        protected void AppSetings()
        {
            var paths = AppData.WsPaths;
            var names = paths.StoreNames;
            for(var i=0; i<names.Length; i++)
            {
                ref readonly var name = ref skip(names,i);
                var path = paths.Path(name);
                Write(string.Format("{0}:{1}", name, path));
            }
        }

        [CmdOp("commands")]
        protected void EmitCommands()
            => EmitCommands(AppDb.ApiTargets().Path(FS.file($"{GetType().Name.ToLower()}.commands", FS.Csv)));

        [CmdOp("env/vars")]
        protected Outcome ShowEnvVars(CmdArgs args)
        {
            var src = EnvVars.records(EnvVars.load());
            iter(src, v => Write(v.Source.Format()));
            AppSvc.TableEmit(src, AppDb.RuntimeLogs().Table<EnvVarRecord>());
            return true;
        }

        [CmdOp("env/settings")]
        protected Outcome ShowEnv(CmdArgs args)
        {
            var result = Outcome.Success;
            var db = EnvWs.create(Wf);
            var settings = args.Count == 0 ? db.Globals() : db.Settings(arg(args,0));
            iter(settings, s => Write(s.Format()));
            return result;
        }

        [CmdOp("env/tools")]
        protected Outcome ShowToolEnv(CmdArgs args)
        {
            LoadToolEnv(out var settings);
            iter(settings, s => Write(s));
            return true;
        }

        [CmdOp("env/logs")]
        protected Outcome EnvLogs(CmdArgs args)
        {
            var result = Outcome.Success;
            var paths = AppDb.Control().Files(FileKind.Log);
            var formatter = Tables.formatter<EnvVarSet>(16, RecordFormatKind.KeyValuePairs);
            foreach(var path in paths)
            {
                var dst = EnvVars.set(path);
                Write(formatter.Format(dst));
            }

            return result;
        }

        [CmdOp("tool/script")]
        protected Outcome ToolScript(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var script = ToolWs.Script(tool, arg(args,1).Value);
            if(!script.Exists)
                return (false, FS.missing(script));
            else
                return OmniScript.Run(script, out var _);
        }

        [CmdOp("tool/config")]
        protected Outcome ConfigureTool(CmdArgs args)
        {
            var result = Outcome.Success;
            ToolId tool = arg(args,0).Value;
            var script = ToolWs.ConfigScript(tool);
            result = OmniScript.Run(script, out var _);
            var logpath = ToolWs.ConfigLog(tool);
            using var reader = logpath.AsciLineReader();
            while(reader.Next(out var line))
            {
                Write(line.Format());
            }

            return result;
        }


        [CmdOp("tool/help")]
        protected Outcome ShowToolHelp(CmdArgs args)
        {
            var result = Outcome.Success;

            var tool = (ToolId)arg(args,0).Value;
            var docs = ToolWs.ToolDocs(tool);
            var doc = docs + FS.file(tool.Format(),FS.Help);
            if(doc.Exists)
            {
                using var reader = doc.Utf8LineReader();
                while(reader.Next(out var line))
                    Write(line.Content);
            }

            return result;
        }

        [CmdOp("tools/settings")]
        protected Outcome ShowToolSettings(CmdArgs args)
        {
            ToolId tool = arg(args,0).Value;
            var src = ToolWs.Logs(tool) + FS.file("config", FS.Log);
            if(!src.Exists)
                return (false,FS.missing(src));

            var settings = AppSettings.Load(src);
            iter(settings, setting => Write(setting));
            return true;
        }

        [CmdOp("tools/docs")]
        protected Outcome ToolDocs(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var path = FS.FilePath.Empty;
            if(args.Length > 1)
                path = ToolWs.ToolDocs(tool) + FS.file(arg(args,1));
            else
                path = ToolWs.ToolDocs(tool) + FS.file(tool.Format(), FS.Help);

            if(path.Exists)
            {
                Write(path.ReadText());
                return true;
            }
            else
                return (false, FS.missing(path));
        }

        [CmdOp("cmd/cd")]
        protected Outcome ChangeDir(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Count == 0)
            {
                Write(CommonState.CurrentDir());
                return result;
            }

            var dst = FS.dir(arg(args,0).Value);
            if(!dst.Exists)
                return (false, FS.missing(dst));
            Write(CommonState.CurrentDir(dst));
            return result;
        }

        [CmdOp("cmd/dir")]
        protected Outcome Dir(CmdArgs args)
        {
            var result = Outcome.Success;

            var spec = string.Empty;
            if(args.Length == 0)
                spec = string.Format("dir {0} /s/b", CommonState.CurrentDir().Format(PathSeparator.BS));
            else
                spec = string.Format("dir {0}\\{1} /s/b", CommonState.CurrentDir().Format(PathSeparator.BS), FS.dir(arg(args,0)).Format(PathSeparator.BS));

            Write(spec);

            result = OmniScript.Run(spec, out var response);
            if(result.Fail)
                return result;

            var count = response.Length;
            var paths = alloc<FS.FilePath>(count);
            for(var i=0; i<count; i++)
                seek(paths,i) = FS.path(skip(response,i).Content);

            return result;
        }

        [CmdOp("runtime/cpucore")]
        protected Outcome ShowCurrentCore(CmdArgs args)
        {
            Wf.Row(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));
            return true;
        }

        protected void UpdateToolEnv(out Settings dst)
        {
            var path = ToolWs.Toolbase.Path(FS.file("show-env-config", FS.Cmd));
            var cmd = CmdLine.create(path.Format(PathSeparator.BS));
            dst = AppSettings.Load(OmniScript.RunCmd(cmd));
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
                Dispatch(CmdSpec.from(lines[i].Content));
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


        protected void LoadToolEnv(out Settings dst)
        {
            var path = ToolWs.Toolbase.Path(FS.file("env", FS.Settings));
            dst = AppSettings.Load(path.ReadNumberedLines());
        }

        void EmitCommands(FS.FilePath dst)
        {
            iter(Dispatcher.SupportedActions, cmd => Write(cmd));
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            iter(Dispatcher.SupportedActions, cmd => writer.WriteLine(cmd));
            EmittedFile(emitting, Dispatcher.SupportedActions.Length);
        }

        protected void Emitted(FS.FilePath dst)
            => Write(string.Format("Emitted {0}", dst.ToUri()));

        protected void DisplayCmdResponse(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            if(count == 0)
                Warn("No response to parse");

            for(var i=0; i<count; i++)
            {
                if(CmdResponse.parse(skip(src,i).Content, out var response))
                    Write(response);
            }
        }

        protected static CmdArg arg(in CmdArgs src, int index)
            => CmdLine.arg(src,index);

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

        protected virtual Outcome DispatchFallback(string command, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", command));

        string Prompt()
            => string.Format("{0}> ", PromptTitle);

        CmdSpec Next()
        {
            var input = term.prompt(Prompt());
            return CmdSpec.from(input);
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

        protected virtual CmdShellState CommonState {get; private set;}
    }

    public abstract class AppCmdService<T,S> : AppCmdService<T>
        where T : AppCmdService<T,S>, new()
        where S : CmdShellState, new()
    {
        protected S State {get;}

        protected AppCmdService()
        {
            State = new S();
        }

        protected override CmdShellState CommonState
            => State;
    }
}