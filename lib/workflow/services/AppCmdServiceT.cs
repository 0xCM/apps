//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static core;

    partial struct Msg
    {
        public static MsgPattern<ProjectId> ProjectUndefined
            => "Project {0} undefined";

        public static MsgPattern<ProjectId> LoadingSources
            => "Loading {0} sources";
    }

    public abstract class AppCmdService<T> : AppService<T>, IAppCmdService, ICmdProvider
        where T : AppCmdService<T>, new()
    {
        public ICmdDispatcher Dispatcher {get; protected set;}

        IWorkerLog Witness;

        Option<IToolCmdShell> Shell;

        protected IProjectSet ProjectWs;

        protected AppCmdService()
        {
            PromptTitle = "cmd";
        }

        protected virtual ICmdProvider[] CmdProviders(IWfRuntime wf)
            => array(this);

        protected override void OnInit()
        {
            Dispatcher = CmdActionDispatcher.discover(CmdProviders(Wf), DispatchFallback);
            ProjectWs = Ws.Projects();
            Witness = Loggers.worker(controller().Id(), ProjectDb.Home(), typeof(T).Name);
        }

        public T With(IToolCmdShell shell)
        {
            Shell = Option.some(shell);
            return (T)this;
        }

        protected void Emitted(FS.FilePath dst)
            => Write(string.Format("Emitted {0}", dst.ToUri()));

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

        [CmdOp(".env")]
        protected Outcome ShowEnv(CmdArgs args)
        {
            var result = Outcome.Success;
            var db = Ws.EnvDb();
            var settings = args.Count == 0 ? db.Globals() : db.Settings(arg(args,0));
            iter(settings, s => Write(s.Format()));
            return result;
        }

        [CmdOp("tools/profiles")]
        protected Outcome ShowToolProfiles(CmdArgs args)
        {
            iter(ToolProfiles.Values, profile => Write(string.Format("{0,-12} {1,-32} {2}", profile.Memberhisp, profile.Id, profile.Path)));
            return true;
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

        /// <summary>
        /// Loads files from a directory into the context
        /// </summary>
        /// <param name="args">The directory specifier, if any</param>
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

            //Files(paths);
            return result;
        }

        [CmdOp("api/catalog")]
        protected Outcome ApiCatalog(CmdArgs args)
        {
            var result = Outcome.Success;
            var parts = ApiRuntimeCatalog.PartIdentities;
            var desc = string.Format("Parts:[{0}]", parts.Map(p => p.Format()).Delimit());
            Write(desc);
            return result;
        }

        [CmdOp(".cpucore")]
        protected Outcome ShowCurrentCore(CmdArgs args)
        {
            Wf.Row(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));
            return true;
        }


        [CmdOp("tool/help")]
        protected Outcome ShowToolHelp(CmdArgs args)
        {
            var result = Outcome.Success;

            var tool = (ToolId)arg(args,0).Value;
            var docs = Tools.ToolDocs(tool);
            var doc = docs + FS.file(tool.Format(),FS.Help);
            if(doc.Exists)
            {
                using var reader = doc.Utf8LineReader();
                while(reader.Next(out var line))
                    Write(line.Content);
            }

            return result;
        }

        [CmdOp("tools/docs")]
        protected Outcome ToolDocs(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var path = FS.FilePath.Empty;
            if(args.Length > 1)
                path = Tools.ToolDocs(tool) + FS.file(arg(args,1));
            else
                path = Tools.ToolDocs(tool) + FS.file(tool.Format(), FS.Help);

            if(path.Exists)
            {
                Write(path.ReadText());
                return true;
            }
            else
                return (false, FS.missing(path));
        }

        protected virtual string PromptTitle {get;}

        protected virtual Outcome DispatchFallback(string command, CmdArgs args)
            => (false, string.Format("Handler for '{0}' not found", command));

        string Prompt()
            => string.Format("{0}> ", PromptTitle);

        CmdSpec Next()
        {
            var input = term.prompt(Prompt());
            return Cmd.cmdspec(input);
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

        protected abstract CmdShellState CommonState {get;}
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