//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/help")]
        Outcome EmitHelp(CmdArgs args)
        {
            Toolset.EmitHelpDocs();
            return true;
        }
    }
}
