//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/query/categories")]
        Outcome XedCategories(CmdArgs args)
            => ShowSyms(Xed.Categories());
    }
}