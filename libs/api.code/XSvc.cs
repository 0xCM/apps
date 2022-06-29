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
            public ApiCode ApiCode(IWfRuntime wf)
                => Service<ApiCode>(wf);

            public ApiCodeFiles ApiCodeFiles(IWfRuntime wf)
                => Service<ApiCodeFiles>(wf);

            public ApiCodeExtractor CodeExtractor(IWfRuntime wf)
                => Service<ApiCodeExtractor>(wf);

            public ApiResolver ApiResolver(IWfRuntime wf)
                => Service<ApiResolver>(wf);

            public ApiResProvider ApiResProvider(IWfRuntime wf)
                => Service<ApiResProvider>(wf);

            public ApiPacks ApiPacks(IWfRuntime wf)
                => Service<ApiPacks>(wf);

            public ApiCatalogs ApiCatalogs(IWfRuntime wf)
                => Service<ApiCatalogs>(wf);

            public ApiIndexBuilder ApiIndexBuilder(IWfRuntime wf)
                =>Service<ApiIndexBuilder>(wf);

        }

        static Svc Services => Svc.Instance;

        public static ApiCode ApiCode(this IWfRuntime wf)
            => Services.ApiCode(wf);

        public static ApiCodeFiles ApiCodeFiles(this IWfRuntime wf)
            => Services.ApiCodeFiles(wf);

        public static ApiCodeExtractor CodeExtractor(this IWfRuntime wf)
            => Services.CodeExtractor(wf);

        public static ApiResolver ApiResolver(this IWfRuntime wf)
            => Services.ApiResolver(wf);

        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Services.ApiResProvider(wf);

        public static ApiPacks ApiPacks(this IWfRuntime wf)
            => Services.ApiPacks(wf);

        public static ApiIndexBuilder ApiIndexBuilder(this IWfRuntime wf)
             => Services.ApiIndexBuilder(wf);

        public static ApiPackages ApiPackages(this IEnvPaths src)
            => src.PackageRoot();

        public static ApiCatalogs ApiCatalogs(this IWfRuntime wf)
            => Services.ApiCatalogs(wf);
    }
}