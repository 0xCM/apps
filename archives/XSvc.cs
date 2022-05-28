//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsLang;

    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
            public HexCsvReader HexCsvReader(IWfRuntime wf)
                => Service<HexCsvReader>(wf);

            public HexCsvWriter HexCsvWriter(IWfRuntime wf)
                => Service<HexCsvWriter>(wf);

            public HexDataReader HexDataReader(IWfRuntime wf)
                => Service<HexDataReader>(wf);

            public HexEmitter HexEmitter(IWfRuntime wf)
                => Service<HexEmitter>(wf);

            public Tooling Tooling(IWfRuntime wf)
                => Service<Tooling>(wf);

            public WsProjects WsProjects(IWfRuntime wf)
                => Service<WsProjects>(wf);

            public WsCmdRunner WsCmdRunner(IWfRuntime wf)
                => Service<WsCmdRunner>(wf);

            public AppDb AppDb(IWfRuntime wf)
                => Service<AppDb>(wf);

            public ApiMd ApiMetadata(IWfRuntime wf)
                => Service<ApiMd>(wf);

            public MsilPipe MsilSvc(IWfRuntime wf)
                => Service<MsilPipe>(wf);

            public ApiJit Jit(IWfRuntime wf)
                => Service<ApiJit>(wf);

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

            public ApiComments ApiComments(IWfRuntime wf)
                => Service<ApiComments>(wf);
        }

        static Svc Services => Svc.Instance;

        public static HexCsvReader HexCsvReader(this IWfRuntime wf)
            => Services.HexCsvReader(wf);

        public static HexCsvWriter HexCsvWriter(this IWfRuntime wf)
            => Services.HexCsvWriter(wf);

        public static HexDataReader HexDataReader(this IWfRuntime wf)
            => Services.HexDataReader(wf);

        public static HexEmitter HexEmitter(this IWfRuntime wf)
            => Services.HexEmitter(wf);

        public static Tooling Tooling(this IWfRuntime wf)
            => Services.Tooling(wf);

        public static WsProjects WsProjects(this IWfRuntime wf)
            => Services.WsProjects(wf);

        public static WsCmdRunner WsCmdRunner(this IWfRuntime wf)
            => Services.WsCmdRunner(wf);

        public static AppDb AppDb(this IWfRuntime wf)
            => Services.AppDb(wf);

        public static ApiMd ApiMetadata(this IWfRuntime wf)
            => Services.ApiMetadata(wf);

        public static MsilPipe MsilSvc(this IWfRuntime wf)
            => Services.MsilSvc(wf);

        public static ApiJit Jit(this IWfRuntime wf)
            => Services.Jit(wf);


        public static CsLang CsLang(this IWfRuntime wf)
            => Services.CsLang(wf);

        public static GStringLits GenLiterals(this IWfRuntime wf)
            => Services.GenLiterals(wf);

        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => Services.GenAsciLookups(wf);

        public static GRecord GenRecords(this IWfRuntime wf)
            => Services.GenRecords(wf);

        public static GLiteralProvider GenLitProviders(this IWfRuntime wf)
            => Services.GenLitProviders(wf);

        public static ApiComments ApiComments(this IWfRuntime wf)
            => Services.ApiComments(wf);


    }
}