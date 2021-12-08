//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string ClassFieldTypeQuery = "llvm/classes/fields/types";

        [CmdOp(ClassFieldTypeQuery)]
        Outcome QueryClassFieldTypes(CmdArgs args)
        {
            Flow(ClassFieldTypeQuery, DataProvider.SelectDistinctFieldTypes(DataProvider.SelectClassFields()));
            return true;
        }
    }
}