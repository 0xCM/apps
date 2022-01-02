//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitIsaForms(arg(args,0).Value);
    }
}