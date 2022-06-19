//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public static partial class XTend
    {

    }

    public static partial class XSvc
    {

        sealed class Svc : AppServices<Svc>
        {
            public ApiCmd ApiCmd(IWfRuntime wf)
                => Service<ApiCmd>(wf);

            public SourceSymbolic SourceSymbolic(IWfRuntime wf)
                => Service<SourceSymbolic>(wf);

        }

        static Svc Services => Svc.Instance;

        public static ApiCmd ApiCmd(this IWfRuntime wf)
            => Services.ApiCmd(wf);

        public static Roslyn Roslyn(this IWfRuntime wf)
            => Z0.Roslyn.create(wf);

        public static SourceSymbolic SourceSymbolic(this IWfRuntime wf)
            => Services.SourceSymbolic(wf);

        public static DumpParser DumpParser(this IWfRuntime wf)
            => Z0.DumpParser.create(wf);

        public static MsDocsService MsDocs(this IWfRuntime wf)
            => Z0.MsDocsService.create(wf);
    }
}