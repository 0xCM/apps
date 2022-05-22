//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string ClassLineageQuery = "llvm/classes/lineage";

        [CmdOp(ClassLineageQuery)]
        Outcome QueryClassLineage(CmdArgs args)
        {
            Query.EmitFile(ClassLineageQuery, DataProvider.SelectClassLineage().Values);
            return true;
        }
    }
}