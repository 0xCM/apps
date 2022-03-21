//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            XedDisasmSvc.EmitDisasmDetail(Context());
            return true;
        }
    }
}