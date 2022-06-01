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
            public Parsers Parsers(IWfRuntime wf)
                => Service<Parsers>(wf);

            public CheckRunner CheckRunner(IWfRuntime wf)
                => Service<CheckRunner>(wf);

            public MemorySeqChecks MemorySeqChecks(IWfRuntime wf)
                => Service<MemorySeqChecks>(wf);

            public CharMapper CharMapper(IWfRuntime wf)
                => Z0.CharMapper.create(wf);

            public FileSplitter FileSplitter(IWfRuntime wf)
                => Service<FileSplitter>(wf);

            public TypeParser TypeParser(IWfRuntime wf)
                => Service<TypeParser>(wf);

            public ApiHex ApiHex(IWfRuntime wf)
                => Service<ApiHex>(wf);
        }

        static Svc Services => Svc.Instance;

        public static Parsers Parsers(this IWfRuntime wf)
            => Services.Parsers(wf);

        public static MemorySeqChecks MemorySeqChecks(this IWfRuntime wf)
            => Services.MemorySeqChecks(wf);

        public static CharMapper CharMapper(this IWfRuntime wf)
            => Services.CharMapper(wf);

        public static FileSplitter FileSplitter(this IWfRuntime wf)
            => Services.FileSplitter(wf);

        public static ApiHex ApiHex(this IWfRuntime wf)
            => Services.ApiHex(wf);

        public static TypeParser TypeParser(this IWfRuntime wf)
            => Services.TypeParser(wf);

        public static ApiCaptureArchive ApiCaptureArchive(this IWfRuntime wf)
            => Z0.ApiCaptureArchive.create(wf);

        public static ApiPackages ApiPackages(this IEnvPaths src)
            => src.PackageRoot();

        public static CheckRunner CheckRunner(this IWfRuntime wf)
            => Services.CheckRunner(wf);
    }
}