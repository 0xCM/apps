//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("llvm/classes/fields")]
        Outcome ClassFields(CmdArgs args)
            => Flow("llvm/classes/fields", DataLoader.LoadClassFields().View);
    }
}