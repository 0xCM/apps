//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string ClassLineageQuery = "llvm/classes/lineage";

        [CmdOp("llvm/emit/lineage")]
        Outcome QueryClassLineage(CmdArgs args)
        {
            Query.FileEmit(ClassLineageQuery, DataProvider.ClassLineage().Values);
            return true;
        }
    }
}