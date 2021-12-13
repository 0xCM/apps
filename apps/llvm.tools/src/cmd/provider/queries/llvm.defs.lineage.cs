//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string DefLineageQuery = "llvm/defs/lineage";

        [CmdOp(DefLineageQuery)]
        Outcome QueryDefLineage(CmdArgs args)
        {
            DataEmitter.EmitQueryResults(DefLineageQuery, DataProvider.SelectDefLineage().Values);
            return true;
        }
    }
}