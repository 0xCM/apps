//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/defs/names")]
        Outcome DefNames(CmdArgs args)
            => Flow("llvm/defs/names", DataProvider.SelectDefNames().View);
    }
}
