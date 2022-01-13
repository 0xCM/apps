//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/fields/types")]
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