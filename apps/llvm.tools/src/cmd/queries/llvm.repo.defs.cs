//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/repo/defs")]
        Outcome LlvmDefs(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.Def));
    }
}