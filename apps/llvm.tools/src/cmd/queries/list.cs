//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames.Queries;

    partial class LlvmCmd
    {
        [CmdOp(list)]
        Outcome ShowList(CmdArgs args)
            => Flow(list, Db.SelectList(arg(args,0)).View);
    }
}