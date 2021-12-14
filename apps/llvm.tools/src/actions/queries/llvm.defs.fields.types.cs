//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string DefFieldTypeQuery = "llvm/defs/fields/types";

        [CmdOp(DefFieldTypeQuery)]
        Outcome QueryDefFieldTypes(CmdArgs args)
        {
            DataEmitter.EmitQueryResults(DefFieldTypeQuery,
                    DataProvider.SelectDistinctFieldTypes(DataProvider.SelectDefFields()).View);
            return true;
        }
    }
}