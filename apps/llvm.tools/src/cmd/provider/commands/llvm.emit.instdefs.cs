//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string EmitInstAction = "llvm/emit/instdefs";

        [CmdOp(EmitInstAction)]
        Outcome EmitInst(CmdArgs args)
        {
            DataEmitter.EmitInstDefs();
            return true;
        }
    }
}