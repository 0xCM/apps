//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/attribs")]
        Outcome CheckOps(CmdArgs args)
        {
            Xed.Rules.EmitInstAttribs(Xed.Rules.CalcInstPatterns());
            return true;
        }
    }
}