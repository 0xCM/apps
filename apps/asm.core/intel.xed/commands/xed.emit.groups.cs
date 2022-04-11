//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/groups")]
        Outcome EmitInstGroups(CmdArgs args)
        {
            Xed.Rules.EmitInstGroups(Xed.Rules.CalcInstPatterns());
           return true;
        }
    }
}