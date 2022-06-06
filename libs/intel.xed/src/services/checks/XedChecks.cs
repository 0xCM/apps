//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedChecks : CheckRunner<XedChecks>
    {
        XedPaths XedPaths => Wf.XedPaths();

        XedRuntime Xed;

        public static XedChecks commands(XedRuntime xed)
        {
            var svc = create(xed.Wf);
            svc.Xed = xed;
            return svc;
        }
   }
}