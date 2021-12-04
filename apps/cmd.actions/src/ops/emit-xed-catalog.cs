//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial class GlobalCommands
    {
        [CmdOp("emit-xed-catalog")]
        protected Outcome EmitXedCat(CmdArgs args)
        {
            Service(Wf.IntelXed).EmitCatalog();
           return true;
        }
    }
}