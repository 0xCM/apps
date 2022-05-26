//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsLang;

    public static class XSvc
    {
        static Svc Services => Svc.Instance;

        sealed class Svc : AppServices<Svc>
        {
            public Parsers Parsers(IWfRuntime wf)
                => Service<Parsers>(wf);

            public WsProjects WsProjects(IWfRuntime wf)
                => Service<WsProjects>(wf);

            public WsCmdRunner WsCmdRunner(IWfRuntime wf)
                => Service<WsCmdRunner>(wf);

            public AppDb AppDb(IWfRuntime wf)
                => Service<AppDb>(wf);

            public ApiResProvider ApiResProvider(IWfRuntime wf)
                => Service<ApiResProvider>(wf);

            public AppSvcOps AppSvc(IWfRuntime wf)
                => Service<AppSvcOps>(wf);

            public CheckRunner CheckRunner(IWfRuntime wf)
                => Service<CheckRunner>(wf);

            public CsLang CsLang(IWfRuntime wf)
                => Service<CsLang>(wf);

            public GStringLits GenLiterals(IWfRuntime wf)
                => Service<GStringLits>(wf);

            public GAsciLookup GenAsciLookups(IWfRuntime wf)
                => Service<GAsciLookup>(wf);

            public GRecord GenRecords(IWfRuntime wf)
                => Service<GRecord>(wf);

            public GLiteralProvider GenLitProviders(IWfRuntime wf)
                => Service<GLiteralProvider>(wf);

            public MemoryEmitter MemoryEmitter(IWfRuntime wf)
                => Service<MemoryEmitter>(wf);

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
        }

        public static Parsers Parsers(this IWfRuntime wf)
            => Services.Parsers(wf);

        public static WsProjects WsProjects(this IWfRuntime wf)
            => Services.WsProjects(wf);

        public static WsCmdRunner WsCmdRunner(this IWfRuntime wf)
            => Services.WsCmdRunner(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => Services.AppDb(wf);

        public static ApiResProvider ApiResProvider(this IWfRuntime wf)
            => Services.ApiResProvider(wf);

        public static AppSvcOps AppSvc(this IWfRuntime wf)
            => Services.AppSvc(wf);

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);

        public static MemorySeqChecks MemorySeqChecks(this IWfRuntime wf)
            => Services.MemorySeqChecks(wf);

        public static MemoryEmitter MemoryEmitter(this IWfRuntime wf)
            => Services.MemoryEmitter(wf);

        public static CsLang CsLang(this IWfRuntime wf)
            => Services.CsLang(wf);

        public static AssetServices Assets(this IWfRuntime wf)
            => Services.Assets(wf);

        public static CharMapper CharMapper(this IWfRuntime wf)
            => Services.CharMapper(wf);

        public static FileSplitter FileSplitter(this IWfRuntime wf)
            => Services.FileSplitter(wf);

        public static GStringLits GenLiterals(this IWfRuntime wf)
            => Services.GenLiterals(wf);

        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => Services.GenAsciLookups(wf);

        public static GRecord GenRecords(this IWfRuntime wf)
            => Services.GenRecords(wf);

        public static GLiteralProvider GenLitProviders(this IWfRuntime wf)
            => Services.GenLitProviders(wf);

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

        public static ApiHexPacks ApiHexPacks(this IWfRuntime wf)
            => Z0.ApiHexPacks.create(wf);

        public static ApiMetadataService ApiMetadata(this IWfRuntime ws)
            => Z0.ApiMetadataService.create(ws);
    }
}