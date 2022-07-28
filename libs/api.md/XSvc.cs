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
            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);

            public ApiCatalogs ApiCatalogs(IWfRuntime wf)
                => Service<ApiCatalogs>(wf);
        }

        static Svc Services => Svc.Instance;

        public static ApiMd ApiMd(this IWfRuntime wf)
            => Services.ApiMetadata(wf);

        public static ApiCatalogs ApiCatalogs(this IWfRuntime wf)
            => Services.ApiCatalogs(wf);

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

    }
}