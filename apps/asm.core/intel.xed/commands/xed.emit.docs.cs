//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/docs")]
        Outcome EmitDocs(CmdArgs args)
        {
            XedDocs.EmitDocs(Xed.Rules.CalcRules(), Xed.Rules.CalcInstPatterns());
            return true;
        }
   }
}