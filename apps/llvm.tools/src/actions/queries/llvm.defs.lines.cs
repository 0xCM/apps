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
            DataEmitter.EmitQueryResults(DefLineQuery, arg(args,0).Value, DataProvider.SelectDefLines(arg(args,0).Value));
            return true;
        }
    }
}