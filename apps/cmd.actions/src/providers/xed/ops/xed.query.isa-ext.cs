//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/query/isa-ext")]
        Outcome XedIsaExt(CmdArgs args)
            => ShowSyms(Xed.IsaExtensions());
    }
}