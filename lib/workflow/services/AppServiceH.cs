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

        public virtual Type EffectiveHost {get;}

        static ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        static object ServiceLock = new();

        public T Service<T>(Func<T> factory)
        {
            lock(ServiceLock)
                return (T)ServiceCache.GetOrAdd(typeof(T), key => factory());
        }

        protected static T service<T>(Func<T> factory)
        {
            lock(ServiceLock)
                return (T)ServiceCache.GetOrAdd(typeof(T), key => factory());
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

        static ConcurrentDictionary<object,object> _Data {get;}
            = new();

        static object DataLock = new();

        [MethodImpl(Inline)]
        protected D Data<D>(object key, Func<D> factory)
        {
            lock(DataLock)
                return (D)_Data.GetOrAdd(key, k => factory());
        }

        [MethodImpl(Inline)]
        protected static D data<D>(object key, Func<D> factory)
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

        public IWfRuntime Wf {get; private set;}

        protected WfHost Host {get; private set;}

        public IWfDb Db {get; private set;}

        protected IProjectDb ProjectDb;

        public EnvData Env {get; private set;}

        protected IEnvPaths Paths => new EnvPaths(Env);

        public IWfEmitters WfEmit {get; private set;}

        protected AppSettings AppSettings => Service(Wf.AppSettings);

        public virtual Type ContractType
            => typeof(H);

        protected Type HostType
            => typeof(H);

        FS.Files _Files;

        public DevWs Ws {get; private set;}

        public IWfMsg WfMsg {get; private set;}

        public void Init(IWfRuntime wf)
        {
            Wf = wf;
            Env = wf.Env;
            WfMsg = new WfMsgSvc(Wf, EffectiveHost, Env);
            WfEmit = new WfEmitters(Wf, EffectiveHost, Env);
            var flow = WfMsg.Creating(EffectiveHost);
            Db = new WfDb(Wf, Env.Db);
            Ws = DevWs.create(Env.DevWs);
            ProjectDb = Ws.ProjectDb();
            OnInit();
            Initialized();
            WfMsg.Created(flow);
        }

        protected AppService()
        {
            Host = new WfHost(typeof(H));
            EffectiveHost = typeof(H);
        }

        protected AppService(IWfRuntime wf)
            : this()
        {
            Wf = wf;
        }

        protected FS.Files Files()
            => _Files;

        protected FS.Files Files(FS.Files src, bool write = true)
        {
            _Files = src;
            if(write)
                iter(src, path => Write(path.ToUri()));
            return Files();
        }

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

        protected void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => WfMsg.Status(content, flair);

        public void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => WfMsg.Status(src, flair);

        protected void Status(string pattern, params object[] args)
            => WfMsg.Status(pattern, args);

        public void Status(FlairKind flair, string pattern, params object[] args)
            => WfMsg.Status(pattern, flair, args);

        protected void Warn<T>(T content)
            => WfMsg.Warn(content);

        protected void Warn(string pattern, params object[] args)
            => WfMsg.Warn(pattern, args);

        protected virtual void Error<T>(T content)
            => WfMsg.Error(content);

        protected WfExecFlow<T> Running<T>(T msg)
            => WfMsg.Running(msg);

        protected WfExecFlow<string> Running([CallerName] string msg = null)
            => WfMsg.Running(msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => WfMsg.Ran(flow,msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => WfMsg.Ran(flow, msg, flair);

        protected void Write<T>(T content)
            => WfMsg.Write(content);

        protected void Write<T>(T content, FlairKind flair)
            => WfMsg.Write(content, flair);

        protected void Write<T>(string name, T value, FlairKind? flair = null)
            => WfMsg.Write(name, value, flair);

        protected void Write<T>(ReadOnlySpan<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                WfMsg.Write(skip(src,i), flair ?? FlairKind.Data);
        }

        protected void Write<T>(Span<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                WfMsg.Write(skip(src,i), flair ?? FlairKind.Data);
        }

        protected void Write<R>(ReadOnlySpan<R> src, ReadOnlySpan<byte> widths)
            where R : struct
        {
            var formatter = Tables.formatter<R>(widths);
            var count = src.Length;
            WfMsg.Write(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                WfMsg.Write(formatter.Format(skip(src,i)));
        }

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

        protected ExecToken TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
                => WfEmit.TableEmit(src,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
                => WfEmit.TableEmit(src, widths, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => WfEmit.TableEmit(src, widths, encoding, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
                => WfEmit.TableEmit(src, widths, writer, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => WfEmit.TableEmit(src, widths, rowpad, encoding, dst);

        protected void FileEmit(string src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8)
            => WfEmit.FileEmit(src, count, dst, encoding);

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

        protected FS.Files ProjectFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        protected FS.FolderPath CgRoot
            => Env.ZDev + FS.folder("codegen");

        protected FS.FolderPath CgDir(string id)
            => CgRoot + FS.folder(id);

        protected Action<IWfEvent> EventLog
            => x => Write(x.Format(), x.Flair);

        protected void EmittedFile(WfFileWritten file, Count count, Arrow<FS.FileUri> flow)
            => Wf.EmittedFile(HostType, file, count);

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

        protected static StatusEvent<T> write<T>(T msg, FlairKind flair = FlairKind.StatusData)
            => EventFactory.status(typeof(H), msg, flair);

        protected static BabbleEvent<T> babble<T>(T msg)
            => EventFactory.babble(typeof(H), msg);

        protected static StatusEvent<T> status<T>(T msg, FlairKind flair = FlairKind.Status)
            => EventFactory.status(typeof(H), msg, flair);

        protected static WarnEvent<T> warn<T>(T msg)
            => EventFactory.warn(typeof(H), msg);

        protected static ErrorEvent<string> error(Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => EventFactory.error(typeof(H), e, caller, file, line);

        protected static ErrorEvent<T> error<T>(T msg, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => EventFactory.error(typeof(H), msg, EventFactory.originate(typeof(H).Name,caller, file, line));

        protected static RunningEvent<T> running<T>(T msg)
            => EventFactory.running(typeof(H), msg);

        protected static RanEvent<T> ran<T>(RunningEvent<T> src)
            => EventFactory.ran(src);

        protected static RanEvent<T> ran<T>(T msg)
            => EventFactory.ran(typeof(H), msg);

        static IApiCatalog _ApiCatalog;

        static object _ApiLocker = new object();

        static IApiCatalog GetApiCatalog()
        {
            lock(_ApiLocker)
            {
                if(_ApiCatalog == null)
                    _ApiCatalog = ApiRuntimeLoader.catalog(true);
            }
            return _ApiCatalog;
        }
    }
}