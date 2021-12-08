//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        const string ClassLineQuery = "llvm/classes/lines";

        [CmdOp(ClassLineQuery)]
        Outcome Class(CmdArgs args)
            => Flow(ClassLineQuery, DataProvider.SelectClassLines(arg(args,0).Value));
    }
}