//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;
    using System.IO;
    using System.Text;

    using static Root;
    using static core;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;

    [WfService]
    public abstract class AppService<H> : IAppService<H>
        where H : AppService<H>, new()
    {
        /// <summary>
        /// Instantites the serice without initialization
        /// </summary>
        [MethodImpl(Inline)]
        protected static H @new() => new H();

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static H create(IWfRuntime wf)
        {
            var service = @new();
            service.Init(wf);
            return service;
        }

        public Identifier HostName {get;}

        ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        ConcurrentDictionary<string,object> _Data {get;}
            = new();

        [MethodImpl(Inline)]
        protected D Data<D>(string key, Func<D> factory)
            => (D)_Data.GetOrAdd(key, k => factory());

        protected T Service<T>(Func<T> factory)
            => (T)ServiceCache.GetOrAdd(typeof(T), key => factory());

        public IWfRuntime Wf {get; private set;}

        protected WfHost Host {get; private set;}

        public IWfDb Db {get; private set;}

        protected IProjectDb ProjectDb;

        ITextBuffer _TextBuffer;

        public EnvData Env => Wf.Env;

        protected IEnvPaths Paths => Wf.EnvPaths;

        protected TableEmitters TableEmitters => Service(Wf.TableEmitters);

        protected AppSettings AppSettings => Service(Wf.AppSettings);

        protected IToolWs Tools => Service(Ws.Tools);

        protected Tooling Tooling => Service(Wf.Tooling);

        protected OmniScript OmniScript => Service(Wf.OmniScript);

        protected ScriptRunner ScriptRunner => Service(Wf.ScriptRunner);

        protected ProjectScripts ProjectScripts => Service(Wf.ProjectScripts);

        protected CmdLineRunner CmdRunner => Service(Wf.CmdLineRunner);

        protected ConstLookup<ToolId,ToolProfile> ToolProfiles
            => Data(nameof(ToolProfiles), () => Tooling.LoadProfiles(Env.Toolbase));

        public virtual Type ContractType
            => typeof(H);

        protected Type HostType
            => typeof(H);

        protected DevWs Ws;

        public void Init(IWfRuntime wf)
        {
            var flow = wf.Creating(typeof(H).Name);
            Host = new WfSelfHost(typeof(H));
            Wf = wf;
            Db = new WfDb(wf, wf.Env.Db);
            Ws = DevWs.create(wf.Env.DevWs);
            ProjectDb = Ws.ProjectDb();
            _Project = ProjectDb;
            OnInit();
            Initialized();
            wf.Created(flow);
        }

        protected AppService()
        {
            HostName = GetType().Name;
            _TextBuffer = text.buffer();
        }

        protected AppService(IWfRuntime wf)
            : this()
        {
            Host = new WfSelfHost(HostName);
            Wf = wf;
        }

        IProjectWs _Project;

        [MethodImpl(Inline)]
        protected virtual IProjectWs Project()
            => _Project;

        [MethodImpl(Inline)]
        protected virtual IProjectWs Project(ProjectId id)
        {
            _Project = Ws.Project(id);
            return Project();
        }

        protected void RedirectEmissions(string name, FS.FolderPath dst)
            => Wf.RedirectEmissions(Loggers.emission(name, dst));

        protected bool Check<T>(Outcome<T> outcome, out T payload)
        {
            if(outcome.Fail)
            {
                Error(outcome.Message ?? "Null error message at Check");
                payload = default;
                return false;
            }
            else
            {
                payload = outcome.Data;
                return true;
            }
        }

        protected IApiCatalog ApiRuntimeCatalog => Service(ApiRuntimeLoader.catalog);

        protected void Babble<T>(T content)
            => Wf.Babble(HostType, content);

        protected void Babble(string pattern, params object[] args)
            => Wf.Babble(HostType, string.Format(pattern,args));

        protected void Status<T>(T content)
            => Wf.Status(HostType, content);

        protected void Status(ReadOnlySpan<char> src)
            => Wf.Status(HostType, new string(src));

        protected void Status(string pattern, params object[] args)
            => Wf.Status(HostType, string.Format(pattern, args));

        protected void Warn<T>(T content)
            => Wf.Warn(HostType, content);

        protected void Warn(string pattern, params object[] args)
            => Wf.Warn(HostType, string.Format(pattern,args));

        protected virtual void Error<T>(T content)
            => Wf.Error(HostType,  core.require(content));

        protected WfExecFlow<T> Running<T>(T msg)
            => Wf.Running(HostType, msg);

        protected WfExecFlow<string> Running([Caller] string msg = null)
            => Wf.Running(HostType, msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, [Caller] string msg = null)
            => Wf.Ran(HostType, flow.WithMsg(msg));

        protected ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(HostType, flow.WithMsg(msg), flair);

        protected WfFileWritten EmittingFile(FS.FilePath dst)
            => Wf.EmittingFile(HostType, dst);

        public ExecToken EmittedFile(WfFileWritten flow, Count count)
            => Wf.EmittedFile(HostType, flow, count);

        protected void EmittedFile(WfFileWritten file, Count count, Arrow<FS.FileUri> flow)
            => Wf.EmittedFile(HostType, file,count);

        protected WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(HostType, dst);

        protected void Write<T>(T content)
            => Wf.Row(content, null);

        protected void Write<T>(T content, FlairKind flair)
            => Wf.Row(content, flair);

        protected void Write<T>(string name, T value, FlairKind? flair = null)
            => Wf.Row(RP.attrib(name, value), flair);

        protected void Write<T>(ReadOnlySpan<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Write(skip(src,i), flair ?? FlairKind.Data);
        }

        protected void Write<T>(Span<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Write(skip(src,i), flair ?? FlairKind.Data);
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

        protected ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(HostType, flow,count, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType,dst);
            var spec = Tables.rowspec<T>();
            var count = Tables.emit(src, spec, dst);
            Wf.EmittedTable(HostType,flow,count);
            return count;
        }

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, dst);
            Wf.EmittedTable(HostType, flow,count);
            return count;
        }

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, encoding, dst);
            Wf.EmittedTable(HostType, flow,count);
            return count;
        }

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, writer);
            Wf.EmittedTable(HostType, flow,count);
            return count;
        }

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, rowpad);
            var count = Tables.emit(src, spec, encoding, dst);
            Wf.EmittedTable(HostType, flow, count);
            return count;
        }

        protected Outcome<uint> EmitLines(ReadOnlySpan<TextLine> src, FS.FilePath dst, TextEncodingKind encoding)
        {
            using var writer = dst.Writer(encoding);
            var count = (uint)src.Length;
            var emitting = Wf.EmittingFile(HostType, dst);
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i));
            Wf.EmittedFile(HostType, emitting,count);
            return count;
        }

        protected void UpdateToolEnv(out Settings dst)
        {
            var path = Tools.Toolbase + FS.file("show-env-config", FS.Cmd);
            var cmd = Cmd.cmdline(path.Format(PathSeparator.BS));
            dst = AppSettings.Load(OmniScript.RunCmd(cmd));
        }

        protected void LoadToolEnv(out Settings dst)
        {
            var path = Tools.Toolbase + FS.file("env", FS.Settings);
            dst = AppSettings.Load(path.ReadNumberedLines());
        }

        protected Outcome RunExe(ReadOnlySpan<ToolCmdFlow> flows)
        {
            if(ToolFlows.target(flows,FS.Exe, out var flow))
            {
                ref readonly var target = ref flow.TargetPath;
                Write(string.Format("Executing {0}", flow.TargetPath.ToUri()));
                var result = OmniScript.Run(target, CmdVars.Empty, true, out var response);
                if(result.Fail)
                    return result;

                for(var j=0; j<response.Length; j++)
                    Write(skip(response, j).Content);
                return true;
            }
            else
                return false;
        }

        protected FS.Files ProjectFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        protected Outcome RunProjectScript(IProjectWs ws, CmdArgs args, ScriptId script, Subject? scope = null)
        {
            var result = Outcome.Success;
            if(args.Count != 0)
            {
                result = OmniScript.RunProjectScript(ws.Project, arg(args,0).Value, script, false, out _);
                return result;
            }

            var src = ProjectFiles(ws, scope).View;
            if(result.Fail)
                return result;

            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                RunProjectScript(ws,path,script);
            }

            return result;
        }

        protected Outcome RunProjectScript(IProjectWs ws, FS.FilePath path, ScriptId script)
        {
            var srcid = path.FileName.WithoutExtension.Format();
            OmniScript.RunProjectScript(ws.Project, srcid, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }

        protected static CmdArg arg(in CmdArgs src, int index)
        {
            if(src.IsEmpty)
                sys.@throw(EmptyArgList.Format());

            var count = src.Length;
            if(count < index - 1)
                sys.@throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

        protected Outcome RunProjectScript(IProjectWs ws, ScriptId script)
        {
            OmniScript.RunProjectScript(ws.Project, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }

        protected ReadOnlySpan<SymLiteralRow> EmitSymLiterals<E>(FS.FilePath dst)
            where E : unmanaged, Enum
        {
            return Service(Wf.Symbolism).EmitLiterals<E>(dst);
        }

        protected ReadOnlySpan<CmdResponse> ParseCmdResponse(ReadOnlySpan<TextLine> src)
            => CmdResponse.parse(src);

        [CmdOp("env/logs")]
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

        [CmdOp("env/tools")]
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

            var settings = AppSettings.Load(src);
            iter(settings, setting => Write(setting));
            return true;
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

        [CmdOp("tools/emit/catalog")]
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

        protected FS.FolderPath CgRoot
            => Env.ZDev + FS.folder("codegen");

        protected FS.FolderPath CgDir(string id)
            => CgRoot + FS.folder(id);
        protected FS.FilePath CgProject(string id)
            => CgDir(id) + FS.file(string.Format("z0.{0}",id), FS.CsProj);


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


        void ReceiveCmdStatus(in string src)
        {

        }

        void ReceiveCmdError(in string src)
        {
            Error(src);
        }

        protected Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(cmd, vars, ReceiveCmdStatus, ReceiveCmdError, out response);

        protected Outcome Run(ToolScript spec, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(spec, ReceiveCmdStatus, ReceiveCmdError, out response);

        protected Outcome RunWinCmd(string spec, out ReadOnlySpan<TextLine> response)
            => CmdRunner.Run(WinCmd.cmd(spec), out response);

        protected Outcome RunScript(FS.FilePath src, out ReadOnlySpan<TextLine> response)
        {
            var result = Outcome.Success;

            void OnError(Exception e)
            {
                result = e;
                Error(e);
            }

            var cmd = Cmd.cmdline(src.Format(PathSeparator.BS));
            response = ScriptRunner.RunCmd(cmd, OnError);
            return result;
        }


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
                var name = symbol.Name;
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

        protected virtual void OnInit()
        {

        }

        protected virtual void Initialized()
        {

        }

        protected virtual void Disposing() { }

        public void Dispose()
        {
            Disposing();
            Wf.Disposed();
        }

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";
    }
}