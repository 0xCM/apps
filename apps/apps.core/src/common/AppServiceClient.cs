//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct ClientFactory<C>
        where C : AppServiceClient<C>, new()
    {
        public static C client(IAppService svc, WsContext context)
            => AppServiceClient<C>.create(svc,context);
    }

    public partial class XTend
    {
        public static C Client<C>(this ClientFactory<C> factory, IAppService svc, WsContext context)
            where C : AppServiceClient<C>, new()
                => AppServiceClient<C>.create(svc, context);

        public static C Client<C>(this IAppService svc, WsContext context)
            where C : AppServiceClient<C>, new()
                => AppServiceClient<C>.create(svc, context);
    }

    public abstract class AppServiceClient
    {
        protected IAppService AppSvc;

        protected WsContext WsContext;

        public static C create<C>(IAppService svc, WsContext context)
            where C : AppServiceClient<C>, new()
                => factory<C>().Client(svc,context);

        public static ClientFactory<C> factory<C>()
            where C : AppServiceClient<C>, new()
                => new ClientFactory<C>();
    }

    public class AppServiceClient<C> : AppServiceClient, IWfTableOps
        where C : AppServiceClient<C>, new()
    {
        protected virtual void Initialized()
        {

        }

        public static C create(IAppService svc, WsContext context)
        {
            var client = new C();
            client.AppSvc = svc;
            client.WsContext = context;
            client.Initialized();
            return client;
        }

        protected IWfRuntime Wf
        {
            [MethodImpl(Inline)]
            get => AppSvc.Wf;
        }

        protected IWfMessaging WfMsg
        {
            [MethodImpl(Inline)]
            get => AppSvc.WfMsg;
        }

        public WsContext Context
        {
            [MethodImpl(Inline)]
            get => WsContext;
        }

        public IWfTableOps TableOps
        {
            [MethodImpl(Inline)]
            get => AppSvc.TableOps;
        }

        public void Babble<T>(T content)
            => WfMsg.Babble(content);

        protected void Babble(string pattern, params object[] args)
            => WfMsg.Babble(pattern, args);

        protected void Status<T>(T content)
            => WfMsg.Status(content);

        public void Status(ReadOnlySpan<char> src)
            => WfMsg.Status(src);

        public void Status(string pattern, params object[] args)
            => WfMsg.Status(pattern, args);

        public void Warn<T>(T content)
            => WfMsg.Warn(content);

        public void Warn(string pattern, params object[] args)
            => WfMsg.Warn(pattern, args);

        public virtual void Error<T>(T content)
            => WfMsg.Error(content);

        public void Write<T>(T content)
            => WfMsg.Write(content);

        public void Write<T>(T content, FlairKind flair)
            => WfMsg.Write(content, flair);

        public void Write<T>(string name, T value, FlairKind? flair = null)
            => WfMsg.Write(name, value, flair);

        public WfExecFlow<T> Running<T>(T msg)
            => WfMsg.Running(msg);

        public WfExecFlow<string> Running([CallerName] string msg = null)
            => WfMsg.Running(msg);

        public ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => WfMsg.Ran(flow,msg);

        public ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => WfMsg.Ran(flow, msg, flair);

        public WfFileWritten EmittingFile(FS.FilePath dst)
            => WfMsg.EmittingFile(dst);

        public ExecToken EmittedFile(WfFileWritten flow, Count count)
            => WfMsg.EmittedFile(flow,count);

        public WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => WfMsg.EmittingTable<T>(dst);

        public ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => WfMsg.EmittedTable(flow,count, dst);

        public void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableOps.TableEmit(src, widths, encoding, dst);

        public void FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => TableOps.FileEmit(src.ToString(), count, dst, encoding);

        public void TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            var formatter = RecordFormatter.create(typeof(T));
            using var emitter = dst.Emitter(encoding);
            emitter.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                emitter.WriteLine(formatter.Format(skip(rows,i)));
            EmittedTable(emitting, rows.Length, dst);
        }

        public void TableEmit<T>(Index<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(rows.View, dst, encoding);

        public void TableEmit<T>(T[] rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(rows), dst, encoding);

        public void TableEmit<T>(Span<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(rows), dst, encoding);

        public T Service<T>(Func<T> factory)
            => AppSvc.Service(factory);

        public void Dispose()
        {
            TableOps.Dispose();
        }

        public AppDb AppDb => Service(Wf.AppDb);


        public static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        public bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        IWfRuntime IWfMessaging.Wf => TableOps.Wf;

        public EnvData Env => TableOps.Env;
    }
}