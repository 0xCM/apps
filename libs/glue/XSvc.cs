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
            public RoslnCmd SourceSymbolic(IWfRuntime wf)
                => Service<RoslnCmd>(wf);

            public Roslyn Roslyn(IWfRuntime wf)
                => Service<Roslyn>(wf);
        }

        static ServiceCache Services => ServiceCache.Instance;

        public static Roslyn Roslyn(this IWfRuntime wf)
            => Services.Roslyn(wf);

        public static RoslnCmd RoslynCmd(this IWfRuntime wf)
            => Services.SourceSymbolic(wf);
    }
}