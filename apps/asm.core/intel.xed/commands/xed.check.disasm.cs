//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedDisasm;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            DisasmFlow.run(this, Context());
            return true;
        }
    }
}