//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/query/chips")]
        Outcome XedChips(CmdArgs args)
            => ShowSyms(Xed.ChipCodes());
    }
}