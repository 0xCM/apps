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
        Outcome EmitFieldTypes(CmdArgs args)
        {
            DataEmitter.EmitQueryResults("llvm/def/fields/types",
                    DataProvider.SelectFieldTypes(DataProvider.SelectDefFields()).View);

            DataEmitter.EmitQueryResults("llvm/classes/fields/types",
                    DataProvider.SelectFieldTypes(DataProvider.SelectClassFields()).View);
            return true;
        }
    }
}