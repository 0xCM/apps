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
            public ApiEmitters ApiEmitters(IWfRuntime wf)
                => Service<ApiEmitters>(wf);

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);

            public ApiServices ApiServices(IWfRuntime wf)
                => Service<ApiServices>(wf);

            public ApiCode ApiCode(IWfRuntime wf)
                => Service<ApiCode>(wf);

            public ApiCodeFiles ApiCodeFiles(IWfRuntime wf)
                => Service<ApiCodeFiles>(wf);

            public Heaps Heaps(IWfRuntime wf)
                => Service<Heaps>(wf);

            public ApiHexPacks HexPack(IWfRuntime wf)
                => Service<ApiHexPacks>(wf);
        }

        static Svc Services => Svc.Instance;

        public static Heaps Heaps(this IWfRuntime wf)
            => Services.Heaps(wf);

        public static ApiEmitters ApiEmitters(this IWfRuntime wf)
            => Services.ApiEmitters(wf);

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);

        public static ApiServices ApiServices(this IWfRuntime wf)
            => Services.ApiServices(wf);

        public static ApiCode ApiCode(this IWfRuntime wf)
            => Services.ApiCode(wf);

        public static ApiCodeFiles ApiCodeFiles(this IWfRuntime wf)
            => Services.ApiCodeFiles(wf);

        public static ApiHexPacks HexPack(this IWfRuntime wf)
            => Services.HexPack(wf);
    }
}