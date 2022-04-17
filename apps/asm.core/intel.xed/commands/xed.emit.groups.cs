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
            var patterns = Xed.Rules.CalcInstPatterns();
            var groups = Xed.Rules.CalcInstGroups(patterns);
            Xed.Rules.EmitInstGroups(groups);
           return true;
        }
    }
}