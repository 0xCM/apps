//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp("classes/fields")]
        Outcome ClassFields(CmdArgs args)
            => Flow("classes/fields", DataProvider.SelectClassFields().View);
    }
}