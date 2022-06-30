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


        }

        static ServiceCache Services => ServiceCache.Instance;


        public static Archives Archives(this IWfRuntime wf)
            => Services.Archives(wf);

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => Services.ScriptRunner(wf);

    }
}