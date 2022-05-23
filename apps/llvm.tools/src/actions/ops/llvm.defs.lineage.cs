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
            Query.EmitFile(DefLineageQuery, DataProvider.DefLineage().Values);
            return true;
        }
    }
}