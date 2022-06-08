//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDisasmSvc : AppService<XedDisasmSvc>
    {
        const string disasm = "xed.disasm";

        AppDb AppDb => Wf.AppDb();

        WsScripts Projects => Wf.WsScripts();

        AppSvcOps AppSvc => Wf.AppSvc();

        XedPaths XedPaths => Xed.Paths;

        XedRuntime Xed;

        public XedDisasmSvc With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => Xed.PllExec;
        }
    }
}