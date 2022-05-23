//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/list/headers")]
        void LlvmHeaders()
            => Flow(LlvmRepo.Files(FS.H));
    }
}