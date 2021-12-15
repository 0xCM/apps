//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string EmitFieldTypesCmd = "llvm/emit/fields/types";

        [CmdOp(EmitFieldTypesCmd)]
        Outcome EmitDefFieldTypes(CmdArgs args)
        {
            DataEmitter.EmitQueryResults(EmitFieldTypesCmd,
                    DataProvider.SelectDistinctFieldTypes(DataProvider.SelectDefFields()).View);
            return true;
        }
    }
}