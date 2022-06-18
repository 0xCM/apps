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

            public XedChecks XedChecks(IWfRuntime wf)
                => Service<XedChecks>(wf);


            public XedCmd XedCmd(IWfRuntime wf)
                => Service<XedCmd>(wf);
        }

        static Svc Services => Svc.Instance;

        public static XedGenSvc XedGenSvc(this IWfRuntime wf)
            => Services.XedGen(wf);

        public static XedChecks XedChecks(this IWfRuntime xed)
            => Services.XedChecks(xed);

        public static XedCmd XedCmd(this IWfRuntime xed)
            => Services.XedCmd(xed);
    }
}