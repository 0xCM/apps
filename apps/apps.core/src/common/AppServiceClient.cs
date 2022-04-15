//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
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

    public class AppServiceClient<C> : AppServiceClient
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

        protected WsContext Context
        {
            [MethodImpl(Inline)]
            get => WsContext;
        }

        protected IWfTableOps TableOps
        {
            [MethodImpl(Inline)]
            get => AppSvc.TableOps;
        }

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

        protected void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableOps.TableEmit(src, widths, encoding, dst);

        protected void FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => TableOps.FileEmit(src.ToString(), count, dst, encoding);

        protected T Service<T>(Func<T> factory)
            => AppSvc.Service(factory);

        protected AppDb AppDb => Service(Wf.AppDb);


        protected static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        protected bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }
    }
}