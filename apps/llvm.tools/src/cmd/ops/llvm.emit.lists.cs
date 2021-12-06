//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/lists")]
        Outcome EmitLists(CmdArgs args)
        {
            LlvmEtl.EmitLists();
            return true;
        }
    }
}