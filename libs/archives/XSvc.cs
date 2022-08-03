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
            public WfCmd WfCmd(IWfRuntime wf)
                => Service<WfCmd>(wf);
        }

        static AppSvcCache Services => AppSvcCache.Instance;

        public static IAppCmdSvc WfCmd(this IWfRuntime wf)
            => Services.WfCmd(wf);
    }
}