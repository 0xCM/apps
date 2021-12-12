//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;

    partial class GlobalCommands
    {
        [CmdOp("nasm/emit/catalog")]
        Outcome EmitNasmCatalog(CmdArgs args)
        {
            Service(Wf.NasmCatalog).ImportInstructions();
            return true;
        }
    }
}