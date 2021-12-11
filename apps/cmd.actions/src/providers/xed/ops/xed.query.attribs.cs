//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/query/attribs")]
        Outcome XedAttribs(CmdArgs args)
            => ShowSyms(Xed.Attributes());
    }
}