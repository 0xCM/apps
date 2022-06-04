//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string DefNameQuery = "llvm/defs/names";

        [CmdOp(DefNameQuery)]
        Outcome DefNames(CmdArgs args)
        {
            Query.FileEmit(DefNameQuery, DataProvider.DefNames().View);
            return true;
        }
    }
}
