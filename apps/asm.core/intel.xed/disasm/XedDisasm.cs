//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasm : AppService<XedDisasm>
    {
        const string disasm = "xed.disasm";

        XedRuntime Xed;

        AppDb AppDb => Wf.AppDb();

        WsProjects Projects => Wf.WsProjects();

        AppSvcOps AppSvc => Wf.AppSvc();

        XedPaths XedPaths => Xed.Paths;

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => Xed.PllExec;
        }

        public XedDisasm With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }
    }
}