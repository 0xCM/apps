//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(@class)]
        Outcome Class(CmdArgs args)
            => Flow(@class, DataProvider.SelectClassLines(arg(args,0).Value));
    }
}