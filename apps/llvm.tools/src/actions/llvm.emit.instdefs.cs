//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/instdefs")]
        Outcome EmitInst(CmdArgs args)
        {
            DataEmitter.EmitInstDefs();
            return true;
        }

    }
}