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
            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public IWsProvider Ws(IWfRuntime wf, FS.FolderPath home)
                => Service(wf, $"WsProvider.{WsProvider.id(home)}", wf => WsProvider.create(wf,home));

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IWsProvider Ws(this IWfRuntime wf, FS.FolderPath home)
            => Services.Ws(wf, home);

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);
    }
}