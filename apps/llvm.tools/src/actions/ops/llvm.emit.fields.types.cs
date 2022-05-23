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
            Query.FileEmit("llvm/def/fields/types", DataProvider.SelectFieldTypes(DataProvider.DefFields()).View);
            Query.FileEmit("llvm/classes/fields/types", DataProvider.SelectFieldTypes(DataProvider.ClassFields()).View);
            return true;
        }
    }
}