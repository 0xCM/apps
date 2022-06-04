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
            public Heaps Heaps(IWfRuntime wf)
                => Service<Heaps>(wf);

        }

        static Svc Services => Svc.Instance;

        public static Heaps Heaps(this IWfRuntime wf)
            => Services.Heaps(wf);
    }
}