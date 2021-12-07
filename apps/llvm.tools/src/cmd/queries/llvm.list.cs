//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/list")]
        Outcome ShowList(CmdArgs args)
            => Flow("list", DataProvider.SelectList(arg(args,0)).Items);
    }
}