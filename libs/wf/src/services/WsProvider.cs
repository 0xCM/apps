//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    class WsProvider : WfSvc<WsProvider>, IWsProvider
    {
        [MethodImpl(Inline)]
        public static WsId id(FS.FolderPath home)
            => home.FolderName.Format();

        public static WsProvider create(IWfRuntime wf, FS.FolderPath home)
        {
            var dst = new WsProvider();
            dst._Log = WsLog.open(home + FS.folder("ws") + FS.file($"", FileKind.Log));
            dst._Id = home.FolderName.Format();
            dst.Home = home;
            dst.Init(wf);
            return dst;
        }

        public FS.FolderPath Home {get; private set;}

        WsLog _Log;

        WsId _Id;

        public ref readonly WsId WsId
        {
            [MethodImpl(Inline)]
            get => ref _Id;
        }

        protected ref readonly WsLog Log
        {
            [MethodImpl(Inline)]
            get => ref _Log;
        }
    }
}