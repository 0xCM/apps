//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public static class XSvc
    {

        sealed class AppSvcCache : AppServices<AppSvcCache>
        {

            public AppSettings AppSettings(IWfRuntime wf)
                => Service<AppSettings>(wf);
        }


        static AppSvcCache Services => AppSvcCache.Instance;

        public static AppSettings AppSettings(this IWfRuntime wf)
            => Services.AppSettings(wf);
    }
}