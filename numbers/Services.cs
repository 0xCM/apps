//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsLang;

    sealed class ServiceCache : AppServices<ServiceCache>
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

        public GLiteralProvider GenLiteralProviders(IWfRuntime wf)
            => Service<GLiteralProvider>(wf);

    }

    public static class XSvc
    {
        static ServiceCache Services => ServiceCache.Instance;

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

        public static GStringLits GenLiterals(this IWfRuntime wf)
            => GStringLits.create(wf);

        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => GAsciLookup.create(wf);

        public static GRecord GenRecords(this IWfRuntime wf)
            => GRecord.create(wf);

        public static GLiteralProvider GenLiteralProviders(this IWfRuntime wf)
            => GLiteralProvider.create(wf);

        public static CsLang CsLang(this IWfRuntime wf)
            => Services.CsLang(wf);
    }
}