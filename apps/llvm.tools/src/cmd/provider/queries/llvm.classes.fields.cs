//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string ClassFieldQuery = "llvm/classes/fields";

        [CmdOp(ClassFieldQuery)]
        Outcome ClassFields(CmdArgs args)
        {
            DataEmitter.EmitQueryResults(ClassFieldQuery, DataProvider.SelectClassFields().View);
            return true;
        }
    }
}