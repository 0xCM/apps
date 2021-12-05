//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {

        [CmdOp("repo/cpp")]
        Outcome LlvmCpp(CmdArgs args)
            => Flow(LlvmRepo.Files(FS.Cpp));
    }
}