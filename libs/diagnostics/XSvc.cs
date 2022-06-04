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
            public SymbolArchive DumpArchives(IWfRuntime wf)
                => Service<SymbolArchive>(wf);

            public ApiSegmentLocator ApiSegments(IWfRuntime wf)
                => Service<ApiSegmentLocator>(wf);

            public Runtime Runtime(IWfRuntime wf)
                => Service<Runtime>(wf);

            public DiagnosticCmd DiagnosticCmd(IWfRuntime wf)
                => Service<DiagnosticCmd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static SymbolArchive SymbolArchives(this IWfRuntime wf)
            => Services.DumpArchives(wf);

        public static ApiSegmentLocator ApiSegments(this IWfRuntime wf)
            => Services.ApiSegments(wf);

        public static Runtime Runtime(this IWfRuntime wf)
            => Services.Runtime(wf);

        public static DiagnosticCmd DiagnosticCmd(this IWfRuntime wf)
            => Services.DiagnosticCmd(wf);
    }
}