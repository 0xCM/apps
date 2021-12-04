//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/classes/names")]
        Outcome ClassNames(CmdArgs args)
            => Flow("llvm/classes/names",Db.ClassNames());
    }
}