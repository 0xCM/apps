//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/rules")]
        Outcome EmitRuleTables(CmdArgs args)
        {
            Xed.Rules.EmitRules(Xed.Rules.CalcRules(), Xed.Rules.CalcInstPatterns());
            return true;
        }
    }
}