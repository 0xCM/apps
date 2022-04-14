//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AppServiceClient<C>
        where C : AppServiceClient<C>, new()
    {
        IAppService AppSvc;

        protected virtual void Initialized()
        {


        }

        public static C create(IAppService svc)
        {
            var client = new C();
            client.AppSvc = svc;
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

        protected IWfTableOps TableOps
        {
            [MethodImpl(Inline)]
            get => AppSvc.TableOps;
        }

        protected void Write<T>(T content)
            => WfMsg.Write(content);

        protected void Status<T>(T content)
            => WfMsg.Status(content);

        protected void Warn<T>(T content)
            => WfMsg.Warn(content);

        protected void Write<T>(T content, FlairKind flair)
            => WfMsg.Write(content, flair);

        protected void Error<T>(T content)
            => WfMsg.Error(content);

        protected void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableOps.TableEmit(src, widths, encoding, dst);

        protected void FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => TableOps.FileEmit(src.ToString(), count, dst, encoding);
    }
}