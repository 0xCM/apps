//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsLang;

    public static class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public CsLang CsLang(IWfRuntime wf)
                => Service<CsLang>(wf);

            public GStringLits GenLiterals(IWfRuntime wf)
                => Service<GStringLits>(wf);

            public GAsciLookup GenAsciLookups(IWfRuntime wf)
                => Service<GAsciLookup>(wf);

            public ApiTableGen ApiTableGen(IWfRuntime wf)
                => Service<ApiTableGen>(wf);

            public GLiteralProvider GenLitProviders(IWfRuntime wf)
                => Service<GLiteralProvider>(wf);

            public GShim GenShims(IWfRuntime wf)
                => Service<GShim>(wf);

            public BuildSvc BuildSvc(IWfRuntime wf)
                => Service<BuildSvc>(wf);

            public BuildCmd BuildCmd(IWfRuntime wf)
                => Service<BuildCmd>(wf);

            public SymbolFactories SymbolFactories(IWfRuntime wf)
                => Service<SymbolFactories>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static CsLang CsLang(this IWfRuntime wf)
            => Services.CsLang(wf);

        public static GStringLits GenLiterals(this IWfRuntime wf)
            => Services.GenLiterals(wf);

        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => Services.GenAsciLookups(wf);

        public static ApiTableGen ApiTableGen(this IWfRuntime wf)
            => Services.ApiTableGen(wf);

        public static GLiteralProvider GenLitProviders(this IWfRuntime wf)
            => Services.GenLitProviders(wf);

        public static GShim GenShims(this IWfRuntime wf)
            => Services.GenShims(wf);

        public static BuildSvc BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);

        public static IAppCmdSvc BuildCmd(this IWfRuntime wf)
            => Services.BuildCmd(wf);

        public static SymbolFactories SymbolFactories(this IWfRuntime wf)
            => Services.SymbolFactories(wf);

    }
}