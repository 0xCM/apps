//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string ClassLineageQuery = "llvm/classes/lineage";

        [CmdOp(ClassLineageQuery)]
        Outcome QueryClassLineage(CmdArgs args)
        {
            var lineage = DataProvider.SelectClassLineage();
            Flow(ClassLineageQuery, lineage.Values);
            return true;
        }
    }
}