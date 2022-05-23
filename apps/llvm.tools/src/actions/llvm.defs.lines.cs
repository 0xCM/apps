//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        const string DefLineQuery = "llvm/defs/lines";

        [CmdOp(DefLineQuery)]
        Outcome Def(CmdArgs args)
        {
            Query.FileEmit(DefLineQuery, arg(args,0).Value, DataProvider.DefLines(arg(args,0).Value));
            return true;
        }
    }
}