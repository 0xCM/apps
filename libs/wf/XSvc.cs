//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public Archives Archives(IWfRuntime wf)
                => Service<Archives>(wf);


            public IWsProvider Ws(IWfRuntime wf, FS.FolderPath home)
                => Service(wf, $"WsProvider.{WsProvider.id(home)}", wf => WsProvider.create(wf,home));
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IWsProvider Ws(this IWfRuntime wf, FS.FolderPath home)
            => Services.Ws(wf, home);
    }
}