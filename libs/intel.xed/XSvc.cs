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
                => Services.Service<XedChecks>(xed.Wf, wf => Z0.XedChecks.commands(xed));

            public XedCmd XedCmd(XedRuntime xed)
                => Services.Service<XedCmd>(xed.Wf, wf => Z0.XedCmd.commands(xed));
        }

        static Svc Services => Svc.Instance;

        public static XedGenSvc XedGenSvc(this IWfRuntime wf)
            => Services.XedGen(wf);

        public static XedChecks XedChecks(this XedRuntime xed)
            => Services.XedChecks(xed);

        public static XedCmd XedCmd(this XedRuntime xed)
            => Services.XedCmd(xed);
    }
}