//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/query/pointers")]
        Outcome XedPointers(CmdArgs args)
            => ShowSyms(Xed.PointerWidths());
    }
}