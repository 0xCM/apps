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

            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public ApiCatalogs ApiCatalogs(IWfRuntime wf)
                => Service<ApiCatalogs>(wf);

            public ApiJit ApiJit(IWfRuntime wf)
                => Service<ApiJit>(wf);
        }

        static Svc Services => Svc.Instance;

        public static ApiMd ApiMetadata(this IWfRuntime wf)
            => Services.ApiMetadata(wf);

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static ApiCatalogs ApiCatalogs(this IWfRuntime wf)
            => Services.ApiCatalogs(wf);

        [Op]
        public static ApiJit ApiJit(this IWfRuntime wf)
            => Services.ApiJit(wf);
    }
}