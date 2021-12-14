//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string ClassFieldTypeQuery = "llvm/classes/fields/types";

        [CmdOp(ClassFieldTypeQuery)]
        Outcome QueryClassFieldTypes(CmdArgs args)
        {
            DataEmitter.EmitQueryResults(ClassFieldTypeQuery, DataProvider.SelectDistinctFieldTypes(DataProvider.SelectClassFields()).View);
            return true;
        }
    }
}