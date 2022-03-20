//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        XedDisasmSvc XedDisasmSvc => Service(Wf.XedDisasm);

        [CmdOp("xed/disasm/emit")]
        Outcome CheckDisasm(CmdArgs args)
        {
            XedDisasmSvc.EmitDisasmDetail(Projects.Context(Project()));
            return true;
        }
    }
}