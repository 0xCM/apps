//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            return true;
        }
    }
}