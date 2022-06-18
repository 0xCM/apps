//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class AppSvcCache : AppServices<AppSvcCache>
        {
            public CheckRunner CheckRunner(IWfRuntime wf)
                => Service<CheckRunner>(wf);

            public WsScripts WsScripts(IWfRuntime wf)
                => Service<WsScripts>(wf);
        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static WsScripts WsScripts(this IWfRuntime wf)
            => Services.WsScripts(wf);


        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);
    }
}