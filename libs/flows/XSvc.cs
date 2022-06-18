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

            public ScriptRunner ScriptRunner(IWfRuntime wf)
                => Service<ScriptRunner>(wf);


        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ScriptRunner ScriptRunner(this IWfRuntime wf)
            => Services.ScriptRunner(wf);

        public static void RedirectEmissions(this IWfRuntime wf, Assembly src, FS.FolderPath dst, Timestamp? ts = null, string name = null)
            => wf.RedirectEmissions(Loggers.emission(src, dst, ts ?? core.timestamp(), name));
    }
}