//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/help-data")]
        Outcome EmitHelpDat(CmdArgs args)
        {
            DataEmitter.EmitToolHelp();
            return true;
        }
    }
}