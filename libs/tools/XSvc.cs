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
            public ToolCmd ToolCmd(IWfRuntime wf)
                => Service<ToolCmd>(wf);

            public ToolScripts ToolScripts(IWfRuntime wf)
                => Service<ToolScripts>(wf);

            public ToolBoxCmd ToolBoxCmd(IWfRuntime wf)
                => Service<ToolBoxCmd>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

        }

        static ServiceCache Services => ServiceCache.Instance;

        public static IAppCmdSvc ToolCmd(this IWfRuntime wf)
            => Services.ToolCmd(wf);

        public static ToolScripts ToolScripts(this IWfRuntime wf)
            => Services.ToolScripts(wf);

        public static IAppCmdSvc ToolBoxCmd(this IWfRuntime wf)
            => Services.ToolBoxCmd(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);             
    }
}