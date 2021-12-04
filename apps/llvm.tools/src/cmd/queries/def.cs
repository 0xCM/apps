//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(def)]
        Outcome Def(CmdArgs args)
            => Flow(def, DataProvider.SelectDefLines(arg(args,0).Value));
    }
}