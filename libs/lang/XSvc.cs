//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CsLang;
    using System.IO;

    partial class XTend
    {
    }

    public static class XSvc
    {
        sealed class Svc : AppServices<Svc>
        {
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

            public GShim GenShims(IWfRuntime wf)
                => Service<GShim>(wf);

            public BuildSvc BuildSvc(IWfRuntime wf)
                => Service<BuildSvc>(wf);
        }

        static Svc Services => Svc.Instance;

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

        public static GShim GenShims(this IWfRuntime wf)
            => Services.GenShims(wf);

        public static BuildSvc BuildSvc(this IWfRuntime wf)
            => Services.BuildSvc(wf);

    }
}