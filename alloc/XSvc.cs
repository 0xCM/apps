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
            public SymHeaps SymHeaps(IWfRuntime wf)
                => Service<SymHeaps>(wf);

            public ApiEmitters ApiEmitters(IWfRuntime wf)
                => Service<ApiEmitters>(wf);

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public ApiServices ApiServices(IWfRuntime wf)
                => Service<ApiServices>(wf);

            public ApiCode ApiCode(IWfRuntime wf)
                => Service<ApiCode>(wf);

            public ApiDataPaths ApiDataPaths(IWfRuntime wf)
                => Service<ApiDataPaths>(wf);
        }

        static Svc Services => Svc.Instance;

        public static SymHeaps SymHeaps(this IWfRuntime wf)
            => Services.SymHeaps(wf);

        public static ApiEmitters ApiEmitters(this IWfRuntime wf)
            => Services.ApiEmitters(wf);

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static ApiServices ApiServices(this IWfRuntime wf)
            => Services.ApiServices(wf);

        public static ApiCode ApiCode(this IWfRuntime wf)
            => Services.ApiCode(wf);

        public static ApiDataPaths ApiDataPaths(this IWfRuntime wf)
            => Services.ApiDataPaths(wf);
    }
}