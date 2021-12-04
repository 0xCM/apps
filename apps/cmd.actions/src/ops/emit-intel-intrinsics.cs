//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static core;
    using static Root;

    partial class GlobalCommands
    {
        [CmdOp("emit-intel-intrinsics")]
        Outcome EmitIntelIntrinsics(CmdArgs args)
        {
            var svc = Service(Wf.IntelIntrinsics);
            svc.Emit();
            return true;
        }

    }
}