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

            public ScriptRunner ScriptRunner(IWfRuntime wf)
                => Service<ScriptRunner>(wf);

            public IWsProvider Ws(IWfRuntime wf, FS.FolderPath home)
                => Service(wf, $"WsProvider.{WsProvider.id(home)}", wf => WsProvider.create(wf,home));

            public AppCmdServer AppCmdServer(IWfRuntime wf)
                => Service<AppCmdServer>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static Archives Archives(this IWfRuntime wf)
            => Services.Archives(wf);

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => Services.ScriptRunner(wf);

        public static IWsProvider Ws(this IWfRuntime wf, FS.FolderPath home)
            => Services.Ws(wf, home);


    }
}