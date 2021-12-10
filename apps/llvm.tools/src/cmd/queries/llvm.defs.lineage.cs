//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string DefLineageQuery = "llvm/defs/lineage";

        [CmdOp(DefLineageQuery)]
        Outcome QueryDefLineage(CmdArgs args)
        {
            var lineage = DataProvider.SelectDefLineage();
            Flow(DefLineageQuery, lineage.Values);
            return true;
        }
    }
}