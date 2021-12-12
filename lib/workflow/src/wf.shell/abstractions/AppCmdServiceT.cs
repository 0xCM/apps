//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;
    using Windows;

    using static Root;
    using static core;

    using L = ApiLiterals;

    public abstract class AppCmdService<T> : AppService<T>, IAppCmdService
        where T : AppCmdService<T>, new()
    {
        public ICmdDispatcher Dispatcher {get; protected set;}

        IWorkerLog Witness;

        Option<IToolCmdShell> Shell;

        protected IProjectSet ProjectWs;

        protected ProjectScripts ProjectScripts;

        protected AppSettings Settings;

        protected IToolWs Tools;

        protected TableEmitters TableEmitters;

        ConcurrentDictionary<string,object> _Data;

        [MethodImpl(Inline)]
        protected D Data<D>(string key, Func<D> factory)
            => (D)_Data.GetOrAdd(key, k => factory());

        protected AppCmdService()
        {
            PromptTitle = "cmd";
            _Data = new();
        }

        protected virtual ICmdProvider[] CmdProviders(IWfRuntime wf) => array(this);

        protected override void OnInit()
        {
            Dispatcher = CmdActionDispatcher.discover(CmdProviders(Wf), DispatchFallback);
            ProjectWs = Ws.Projects();
            Witness = Loggers.worker(controller().Id(), ProjectDb.Home(), typeof(T).Name);
            ProjectScripts = Wf.ProjectScripts();
            Settings = Wf.AppSettings();
            TableEmitters = Wf.TableEmitters();
            Tools = Ws.Tools();
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

        protected void UpdateToolEnv(out Settings dst)
        {
            var path = Tools.Toolbase + FS.file("show-env-config", FS.Cmd);
            var cmd = Cmd.cmdline(path.Format(PathSeparator.BS));
            dst = Settings.Load(OmniScript.RunCmd(cmd));
        }

        protected void LoadToolEnv(out Settings dst)
        {
            var path = Tools.Toolbase + FS.file("env", FS.Settings);
            dst = Settings.Load(path.ReadNumberedLines());
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

        [CmdOp(".env-logs")]
        protected Outcome EnvLogs(CmdArgs args)
        {
            var result = Outcome.Success;
            var ext = FS.ext("env") + FS.Log;
            var paths = Ws.Tools().AdminFiles(ext);
            var formatter = Tables.formatter<EnvVarSet>();
            foreach(var path in paths)
            {
                result = EnvVarSet.parse(path, out var dst);
                if(result.Fail)
                    return result;
                Write(formatter.Format(dst, RecordFormatKind.KeyValuePairs));
            }

            return result;
        }

        [CmdOp("env/vars")]
        protected Outcome ShowEnvVars(CmdArgs args)
        {
            var vars = Z0.Env.vars();
            iter(vars, v => Write(v));
            return true;
        }

        [CmdOp("tools/env")]
        protected Outcome ShowToolEnv(CmdArgs args)
        {
            LoadToolEnv(out var settings);
            iter(settings, s => Write(s));
            return true;
        }

        [CmdOp("tools/settings")]
        protected Outcome ShowToolSettings(CmdArgs args)
        {
            ToolId tool = arg(args,0).Value;
            var src = Tools.Logs(tool) + FS.file("config", FS.Log);
            if(!src.Exists)
                return (false,FS.missing(src));

            var settings = OptionReader.settings(src);
            iter(settings, setting => Write(setting));
            return true;
        }

        [CmdOp("commands")]
        protected Outcome Commands(CmdArgs args)
        {
            var commands = Cmd.cmdops(GetType());
            iter(commands, cmd => Write(cmd.Format()));
            return true;
        }

        [CmdOp(".project")]
        protected Outcome Project(CmdArgs args)
        {
            var outcome = Outcome.Success;
            if(args.Length == 0)
                return LoadProjectSources(Project());
            else
                return LoadProjectSources(CommonState.Project(arg(args,0).Value));
        }

        [CmdOp(".srcfiles")]
        protected Outcome ProjectSrcFiles(CmdArgs args)
        {
            if(args.Length == 0)
                Files(Project().SrcFiles());
            else
                Files(Project().SrcFiles(arg(args,0)));
            return true;
        }

        [CmdOp(".files")]
        protected Outcome ShowFiles(CmdArgs args)
        {
            var result = Outcome.Success;
            var files = CommonState.Files();
            iter(files, file => Write(file.ToUri()));
            return result;
        }

        [CmdOp(".cd")]
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
        [CmdOp(".dir")]
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

            Files(paths);
            return result;
        }

        [CmdOp("api/catalog")]
        protected Outcome ApiCatalog(CmdArgs args)
        {
            var result = Outcome.Success;
            var catalog = Service(ApiRuntimeLoader.catalog);
            var parts = catalog.PartIdentities;
            var desc = string.Format("Parts:[{0}]", parts.Map(p => p.Format()).Delimit());
            Write(desc);
            return result;
        }

        Index<CompilationLiteral> ApiLiterals()
            => L.CompilationLiterals(ApiRuntimeLoader.assemblies());

        [CmdOp("api/emit/literals")]
        protected Outcome EmitApiLiterals(CmdArgs args)
        {
            var result = Outcome.Success;
            var literals = CommonState.ApiLiterals(ApiLiterals);
            var path = TableEmitters.Emit(literals, Ws.Tables().Subdir(WsAtoms.machine));
            return result;
        }

        [CmdOp(".cpucore")]
        protected Outcome ShowCurrentCore(CmdArgs args)
        {
            Wf.Row(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));
            return true;
        }

        [CmdOp("tool/config")]
        protected Outcome ConfigureTool(CmdArgs args)
        {
            var result = Outcome.Success;
            ToolId tool = arg(args,0).Value;
            var script = Tools.ConfigScript(tool);
            result = OmniScript.Run(script, out var _);
            var logpath = Tools.ConfigLog(tool);
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

        [CmdOp("tool/script")]
        protected Outcome ToolScript(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var script = Tools.Script(tool, arg(args,1).Value);
            if(!script.Exists)
                return (false, FS.missing(script));
            else
                return OmniScript.Run(script, out var _);
        }

        [CmdOp("tools/catalog")]
        protected Outcome CatalogTools(CmdArgs args)
        {
            var subdirs = Tools.Root.SubDirs();
            var counter = 0u;
            var formatter = Tables.formatter<ToolConfig>();
            var dst = Tools.Inventory();
            using var writer = dst.AsciWriter();
            foreach(var dir in subdirs)
            {
                var configCmd = dir + FS.file(WsAtoms.config, FS.Cmd);
                if(configCmd.Exists)
                {
                    var config =  dir + FS.folder(WsAtoms.logs) + FS.file(WsAtoms.config, FS.Log);
                    if(config.Exists)
                    {
                        var result = Tooling.parse(config.ReadText(), out var c);
                        if(result.Fail)
                        {
                            Error(string.Format("{0}:{1}", config.ToUri(), result.Message));
                            continue;
                        }

                        var settings = formatter.Format(c,RecordFormatKind.KeyValuePairs);
                        var title = string.Format("# {0}", c.ToolId);
                        var sep = string.Format("# {0}", RP.PageBreak80);

                        Write(title, FlairKind.Status);
                        Write(sep);
                        Write(settings);
                        writer.WriteLine(title);
                        writer.WriteLine(sep);
                        writer.WriteLine(settings);
                        counter++;
                    }
                }
            }

            Write(string.Format("{0} tools cataloged: {1}", counter, dst.ToUri()));
            return true;
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

        public void Run()
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

        public Outcome Dispatch(CmdSpec cmd)
        {
            var outcome = Dispatcher.Dispatch(cmd.Name, cmd.Args);
            if(outcome.Fail)
                Error(outcome.Message);
            else
            {
                if(nonempty(outcome.Message))
                    Status(outcome.Message);
            }
            return outcome;
        }

        public Outcome Dispatch(string command, CmdArgs args)
            => Dispatcher.Dispatch(command, args);

        public Outcome Dispatch(string command)
            => Dispatcher.Dispatch(command);

        public ReadOnlySpan<string> Supported
            => Dispatcher.Supported;

        protected Outcome ShowSyms<K>(Symbols<K> src)
            where K : unmanaged
        {
            const string Pattern1 = "{0,-4} {1}";
            const string Pattern2 = "{0,-4} {1}('{2}')";
            var count = src.Length;
            var view = src.View;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(view,i);
                var key = symbol.Key;
                var name = symbol.Name.Format();
                var expr = symbol.Expr.Format();
                if(name.Equals(expr))
                    Write(string.Format(Pattern1, key, expr));
                else
                    Write(string.Format(Pattern2, key, name, expr));
            }
            return true;
        }

        protected Index<SymKindRow> EmitSymKinds<K>(in Symbols<K> src, FS.FilePath dst)
            where K : unmanaged
        {
            var result = Outcome.Success;
            var kinds = src.Kinds;
            var count = kinds.Length;
            var buffer = alloc<SymKindRow>(count);
            Symbols.kinds(src,buffer);
            TableEmit(@readonly(buffer), SymKindRow.RenderWidths, dst);
            return buffer;
        }

        protected void Write<R>(ReadOnlySpan<R> src, ReadOnlySpan<byte> widths)
            where R : struct
        {
            var formatter = Tables.formatter<R>(widths);
            var count = src.Length;
            Write(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                Write(formatter.Format(skip(src,i)));
        }

        protected ReadOnlySpan<CmdResponse> ParseCmdResponse(ReadOnlySpan<TextLine> src)
            => CmdResponse.parse(src);


        protected abstract CmdShellState CommonState {get;}

        protected FS.Files Files()
            => CommonState.Files();

        protected IProjectWs Project()
            => CommonState.Project();

        protected FS.Files Files(FS.Files src, bool write = true)
        {
            CommonState.Files(src);
            if(write)
                iter(src.View, f => Write(f.ToUri()));
            return src;
        }

        protected Outcome LoadProjectSources(IProjectWs ws)
        {
            var outcome = Outcome.Success;
            var dir = ws.Home();
            outcome = dir.Exists;
            if(outcome)
                Files(ws.SrcFiles());
            else
                outcome = (false, UndefinedProject.Format(ws.Project));
            return outcome;
        }

        protected Outcome LoadProjectSources(IProjectWs ws, Subject? scope)
        {
            Files(ProjectFiles(ws,scope));
            return true;
        }

        protected Outcome RunProjectScript(CmdArgs args, ScriptId script, Subject? scope = null)
            => RunProjectScript(CommonState.Project(), args, script, scope);

        static MsgPattern<ProjectId> UndefinedProject
            => "Undefined project:{0}";

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";
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