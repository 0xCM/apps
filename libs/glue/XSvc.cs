//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public static partial class XTend
    {

    }

    public static partial class XSvc
    {
        sealed class ServiceCache : AppServices<ServiceCache>
        {
            public SourceSymbolic SourceSymbolic(IWfRuntime wf)
                => Service<SourceSymbolic>(wf);

            public Roslyn Roslyn(IWfRuntime wf)
                => Service<Roslyn>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static Roslyn Roslyn(this IWfRuntime wf)
            => Services.Roslyn(wf);
        public static SourceSymbolic SourceSymbolic(this IWfRuntime wf)
            => Services.SourceSymbolic(wf);
    }
}