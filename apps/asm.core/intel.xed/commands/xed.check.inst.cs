//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/inst")]
        Outcome CheckInstDefs(CmdArgs args)
        {
            return true;
        }
    }
}