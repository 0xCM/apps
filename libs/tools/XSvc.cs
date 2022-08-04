//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        class ServiceCache : AppServices<ServiceCache>
        {

            public ToolScripts ToolScripts(IWfRuntime wf)
                => Service<ToolScripts>(wf);

            public ToolCmd ToolCmd(IWfRuntime wf)
                => Service<ToolCmd>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static ToolScripts ToolScripts(this IWfRuntime wf)
            => Services.ToolScripts(wf);

        public static IAppCmdSvc ToolCmd(this IWfRuntime wf)
            => Services.ToolCmd(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);             
    }
}