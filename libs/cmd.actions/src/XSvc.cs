//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public CheckCmd CheckCmd(IWfRuntime wf)
                => Service<CheckCmd>(wf);

            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

            public ProjectCmd ProjectCmd(IWfRuntime wf, ICmdRunner runner)
                => Service(() => Z0.ProjectCmd.create(wf).With(runner));
        }

        static Svc Services = Svc.Instance;

        public static CheckCmd CheckCmd(this IWfRuntime wf)
            => Services.CheckCmd(wf);

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

        public static ProjectCmd ProjectCmd(this IWfRuntime wf, ICmdRunner runner)
            => Services.ProjectCmd(wf, runner);

    }
}