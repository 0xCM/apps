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
            public AppDb AppDb(IWfRuntime wf)
                => Service<AppDb>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public OmniScript OmniScript(IWfRuntime wf)
                => Service<OmniScript>(wf);
        }

        static Svc Services => Svc.Instance;

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => Services.AppDb(wf);

        public static OmniScript OmniScript(this IWfRuntime wf)
            => Services.OmniScript(wf);

        public static void RedirectEmissions(this IWfRuntime wf, string name, FS.FolderPath dst)
            => wf.RedirectEmissions(Loggers.emission(name, dst));

        [Op]
        public static ApiIndexBuilder ApiIndexBuilder(this IWfRuntime wf)
             => Z0.ApiIndexBuilder.create(wf);

    }
}