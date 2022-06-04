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
            public XedGenSvc XedGen(IWfRuntime wf)
                => Service<XedGenSvc>(wf);

            public XedChecks XedChecks(XedRuntime xed)
                => Services.Service<XedChecks>(xed.Wf, wf => Z0.XedChecks.create(wf, xed));
        }

        static Svc Services => Svc.Instance;

        public static XedGenSvc XedGenSvc(this IWfRuntime wf)
            => Services.XedGen(wf);

        public static XedChecks XedChecks(this XedRuntime xed)
            => Services.XedChecks(xed);
    }
}