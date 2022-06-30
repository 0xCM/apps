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
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static SqlDbCmd SqlDbCmd(this IWfRuntime wf)
            => Services.SqlDbCmd(wf);
    }
}