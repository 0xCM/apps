//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string ClassFieldQuery = "llvm/classes/fields";

        [CmdOp(ClassFieldQuery)]
        Outcome ClassFields(CmdArgs args)
            => Flow(ClassFieldQuery, DataProvider.SelectClassFields().View);
    }
}