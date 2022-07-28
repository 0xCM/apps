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
            public SqlDbCmd SqlDbCmd(IWfRuntime wf)
                => Service<SqlDbCmd>(wf);

            public SqlDb SqlDb(IWfRuntime wf)
                => Service<SqlDb>(wf);

            public WsDb WsDb(IWfRuntime wf)
                => Service<WsDb>(wf);

            public WsDbCmd WsDbCmd(IWfRuntime wf)
                => Service<WsDbCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static SqlDbCmd SqlDbCmd(this IWfRuntime wf)
            => Services.SqlDbCmd(wf);

        public static WsDbCmd WsDbCmd(this IWfRuntime wf)
            => Services.WsDbCmd(wf);

        public static WsDb WsDb(this IWfRuntime wf)
            => Services.WsDb(wf);

        public static SqlDb SqlDb(this IWfRuntime wf)
            => Services.SqlDb(wf);
    }
}