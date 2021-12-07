//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string EmitHelpData = "llvm/emit/help-data";

        [CmdOp(EmitHelpData)]
        Outcome ExecEmitHelpData(CmdArgs args)
        {
            DataEmitter.EmitToolHelp();
            return true;
        }
    }
}