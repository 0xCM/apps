//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string DefNameQuery = "llvm/defs/names";

        [CmdOp(DefNameQuery)]
        Outcome DefNames(CmdArgs args)
            => Flow(DefNameQuery, DataProvider.SelectDefNames().View);
    }
}
