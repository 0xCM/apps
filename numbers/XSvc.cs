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

            public Parsers Parsers(IWfRuntime wf)
                => Service<Parsers>(wf);

            public ApiResProvider ApiResProvider(IWfRuntime wf)
                => Service<ApiResProvider>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public CheckRunner CheckRunner(IWfRuntime wf)
                => Service<CheckRunner>(wf);

            public MemorySeqChecks MemorySeqChecks(IWfRuntime wf)
                => Service<MemorySeqChecks>(wf);

            public AssetServices Assets(IWfRuntime wf)
                => Service<AssetServices>(wf);

            public CharMapper CharMapper(IWfRuntime wf)
                => Z0.CharMapper.create(wf);

            public FileSplitter FileSplitter(IWfRuntime wf)
                => Service<FileSplitter>(wf);

            public ApiResolver ApiResolver(IWfRuntime wf)
                => Service<ApiResolver>(wf);

            public TypeParser TypeParser(IWfRuntime wf)
                => Service<TypeParser>(wf);

            public ApiCatalogs ApiCatalogs(IWfRuntime wf)
                => Service<ApiCatalogs>(wf);

            public ApiHex ApiHex(IWfRuntime wf)
                => Service<ApiHex>(wf);


        }

        static Svc Services => Svc.Instance;

        public static Parsers Parsers(this IWfRuntime wf)
            => Services.Parsers(wf);

        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Services.ApiResProvider(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static MemorySeqChecks MemorySeqChecks(this IWfRuntime wf)
            => Services.MemorySeqChecks(wf);

        public static AssetServices Assets(this IWfRuntime wf)
            => Services.Assets(wf);

        public static CharMapper CharMapper(this IWfRuntime wf)
            => Services.CharMapper(wf);

        public static FileSplitter FileSplitter(this IWfRuntime wf)
            => Services.FileSplitter(wf);

        public static ApiHex ApiHex(this IWfRuntime wf)
            => Services.ApiHex(wf);

        public static ApiResolver ApiResolver(this IWfRuntime wf)
            => Services.ApiResolver(wf);

        public static TypeParser TypeParser(this IWfRuntime wf)
            => Services.TypeParser(wf);

        public static ApiCatalogs ApiCatalogs(this IWfRuntime wf)
            => Services.ApiCatalogs(wf);

        public static ScriptRunner ScriptRunner(this IEnvPaths paths)
            => Z0.ScriptRunner.create(paths);

        public static ApiCaptureArchive ApiCaptureArchive(this IWfRuntime wf)
            => Z0.ApiCaptureArchive.create(wf);

        public static ApiPackages ApiPackages(this IEnvPaths src)
            => src.PackageRoot();

        public static AppDb AppDb(this IWfRuntime wf)
            => Services.AppDb(wf);

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);

    }
}