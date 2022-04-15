//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

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

        static ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        static object ServiceLock = new();

        static ConcurrentDictionary<string,object> _Data {get;}
            = new();

        static object DataLock = new();

        [MethodImpl(Inline)]
        protected D Data<D>(string key, Func<D> factory)
        {
            lock(DataLock)
                return (D)_Data.GetOrAdd(key, k => factory());
        }

        [MethodImpl(Inline)]
        protected void ClearCache()
        {
            lock(DataLock)
                _Data.Clear();
        }

        public T Service<T>(Func<T> factory)
        {
            lock(ServiceLock)
                return (T)ServiceCache.GetOrAdd(typeof(T), key => factory());
        }

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

        public OmniScript OmniScript => Service(Wf.OmniScript);

        protected ScriptRunner ScriptRunner => Service(Wf.ScriptRunner);

        protected CmdLineRunner CmdRunner => Service(Wf.CmdLineRunner);

        protected ConstLookup<ToolId,ToolProfile> ToolProfiles
            => Data(nameof(ToolProfiles), () => Tooling.LoadProfiles(Env.Toolbase));

        public virtual Type ContractType
            => typeof(H);

        protected Type HostType
            => typeof(H);

        DevWs _Ws;

        public DevWs Ws
        {
            [MethodImpl(Inline)]
            get => _Ws;
        }

        WfMessaging _WfMsg;

        public IWfMessaging WfMsg
        {
            [MethodImpl(Inline)]
            get => _WfMsg;
        }

        WfTableOps _TableOps;

        public IWfTableOps TableOps
        {
            [MethodImpl(Inline)]
            get => _TableOps;
        }

        public void Init(IWfRuntime wf)
        {
            var flow = wf.Creating(typeof(H).Name);
            Host = new WfSelfHost(typeof(H));
            Wf = wf;
            _WfMsg = new WfMessaging(wf, Env);
            _TableOps = new WfTableOps(wf,Env);
            Db = new WfDb(wf, wf.Env.Db);
            _Ws = DevWs.create(wf.Env.DevWs);
            ProjectDb = Ws.ProjectDb();
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


        FS.Files _Files;

        protected FS.Files Files()
            => _Files;

        protected FS.Files Files(FS.Files src, bool write = true)
        {
            _Files = src;
            if(write)
                iter(src, path => Write(path.ToUri()));
            return Files();
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

        protected IApiCatalog ApiRuntimeCatalog => GetApiCatalog();

        protected void Babble<T>(T content)
            => WfMsg.Babble(content);

        protected void Babble(string pattern, params object[] args)
            => WfMsg.Babble(pattern, args);

        protected void Status<T>(T content)
            => WfMsg.Status(content);

        protected void Status(ReadOnlySpan<char> src)
            => WfMsg.Status(src);

        protected void Status(string pattern, params object[] args)
            => WfMsg.Status(pattern, args);

        protected void Warn<T>(T content)
            => WfMsg.Warn(content);

        protected void Warn(string pattern, params object[] args)
            => WfMsg.Warn(pattern, args);

        protected virtual void Error<T>(T content)
            => WfMsg.Error(content);

        protected void Write<T>(T content)
            => WfMsg.Write(content);

        protected void Write<T>(T content, FlairKind flair)
            => WfMsg.Write(content, flair);

        protected void Write<T>(string name, T value, FlairKind? flair = null)
            => WfMsg.Write(name, value, flair);

        protected WfExecFlow<T> Running<T>(T msg)
            => WfMsg.Running(msg);

        protected WfExecFlow<string> Running([CallerName] string msg = null)
            => WfMsg.Running(msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => WfMsg.Ran(flow,msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => WfMsg.Ran(flow, msg, flair);

        protected WfFileWritten EmittingFile(FS.FilePath dst)
            => WfMsg.EmittingFile(dst);

        public ExecToken EmittedFile(WfFileWritten flow, Count count)
            => WfMsg.EmittedFile(flow,count);

        protected WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => WfMsg.EmittingTable<T>(dst);

        protected ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => WfMsg.EmittedTable(flow,count, dst);

        protected void Show(Outcome result)
        {
            if(result)
            {
                if(text.nonempty(result.Message))
                    Status(result.Message);
                else
                    Status("Success");
            }
            else
            {
                if(text.nonempty(result.Message))
                    Error(result.Message);
                else
                    Error("Failure");
            }
        }


        protected uint TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
                => TableOps.TableEmit(src,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
                => TableOps.TableEmit(src, widths, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => TableOps.TableEmit(src, widths, encoding, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
                => TableOps.TableEmit(src, widths, writer, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => TableOps.TableEmit(src, widths, rowpad, encoding, dst);

        protected void FileEmit(string src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8)
            => TableOps.FileEmit(src, count, dst, encoding);

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

        protected FS.Files ProjectFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
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

        protected ReadOnlySpan<SymLiteralRow> EmitSymLiterals<E>(FS.FilePath dst)
            where E : unmanaged, Enum
        {
            return Service(Wf.Symbolism).EmitLiterals<E>(dst);
        }

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

        protected void EmittedFile(WfFileWritten file, Count count, Arrow<FS.FileUri> flow)
            => Wf.EmittedFile(HostType, file, count);

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

        static IApiCatalog _ApiCatalog;

        static object _ApiLocker = new object();

        static IApiCatalog GetApiCatalog()
        {
            lock(_ApiLocker)
            {
                if(_ApiCatalog == null)
                {
                    _ApiCatalog = ApiRuntimeLoader.catalog();
                }
            }
            return _ApiCatalog;
        }

        static ConcurrentDictionary<string,object> _ServiceState {get;}
            = new();

        [MethodImpl(Inline)]
        protected static D state<D>(string key, Func<D> factory)
            => (D)_ServiceState.GetOrAdd(key, k => factory());

        [MethodImpl(Inline)]
        protected static ref readonly D state<D>(string key, out D dst)
        {
            dst = (D)_ServiceState[key];
            return ref dst;
        }

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";
    }
}