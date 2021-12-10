//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;


    partial class LlvmCmd
    {
        const string DefRelationsQuery = "llvm/defs/relations";

        [CmdOp(DefRelationsQuery)]
        Outcome SelectDefRelations(CmdArgs args)
        {
            var relations = DataProvider.SelectDefRelationArrows();
            Flow(DefRelationsQuery, relations);
            return true;
        }
    }
}