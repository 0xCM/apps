//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/isapages")]
        Outcome EmitIsaPages(CmdArgs args)
        {
            //Xed.Patterns.EmitIsaPages(Xed.Rules.CalcTableSet(), Xed.Rules.CalcInstPatterns());
            return true;
        }
    }
}