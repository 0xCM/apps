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
            public ProjectDataServices ProjectData(IWfRuntime wf)
                => Service<ProjectDataServices>(wf);

            public CheckCmd CheckCmd(IWfRuntime wf)
                => Service<CheckCmd>(wf);
        }

        static Svc Services = Svc.Instance;

        public static ProjectDataServices ProjectData(this IWfRuntime wf)
            => Services.ProjectData(wf);

        internal static CheckCmd CheckCmd(this IWfRuntime wf)
            => Services.CheckCmd(wf);
    }
}