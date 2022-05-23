//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/emit/list")]
        Outcome ShowList(CmdArgs args)
            => Flow("list", DataProvider.List(arg(args,0)).Items);
    }
}