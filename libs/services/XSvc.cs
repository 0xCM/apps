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
            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public WsScripts WsScripts(IWfRuntime wf)
                => Service<WsScripts>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

            public WsCmdRunner WsCmdRunner(IWfRuntime wf)
                => Service<WsCmdRunner>(wf);

            public CheckRunner CheckRunner(IWfRuntime wf)
                => Service<CheckRunner>(wf);

        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static WsScripts WsScripts(this IWfRuntime wf)
            => Services.WsScripts(wf);

        public static WsCmdRunner WsCmdRunner(this IWfRuntime wf)
            => Services.WsCmdRunner(wf);

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);
    }
}