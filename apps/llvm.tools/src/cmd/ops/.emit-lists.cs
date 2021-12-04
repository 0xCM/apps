//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static Root;

    partial class LlvmCmd
    {
        [CmdOp(".emit-lists")]
        Outcome EmitLists(CmdArgs args)
        {
            LlvmEtl.EmitLists();
            return true;
        }
    }
}