//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string DefLineQuery = "llvm/defs/lines";

        [CmdOp(DefLineQuery)]
        Outcome Def(CmdArgs args)
            => Flow(DefLineQuery, DataProvider.SelectDefLines(arg(args,0).Value));
    }
}