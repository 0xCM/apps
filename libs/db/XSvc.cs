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

            public DbCmd DbCmd(IWfRuntime wf)
                => Service<DbCmd>(wf);

            public WsDbCmd WsDbCmd(IWfRuntime wf)
                => Service<WsDbCmd>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static SqlDbCmd SqlDbCmd(this IWfRuntime wf)
            => Services.SqlDbCmd(wf);

        public static WsDbCmd WsDbCmd(this IWfRuntime wf)
            => Services.WsDbCmd(wf);

        public static ICmdProvider DbCmd(this IWfRuntime wf)
            => Services.DbCmd(wf);

    }
}