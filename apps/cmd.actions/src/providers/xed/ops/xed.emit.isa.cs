//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitChipForms(arg(args,0).Value);
    }
}