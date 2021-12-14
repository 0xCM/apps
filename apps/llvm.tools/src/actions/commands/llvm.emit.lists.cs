//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/lists")]
        Outcome EmitLists(CmdArgs args)
        {
            DataEmitter.EmitLists();
            return true;
        }
    }
}