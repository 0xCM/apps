//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Collections.Generic;
global using System.Collections.Concurrent;

global using static Z0.Root;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;

[assembly: PartId(PartId.CmdActions)]
namespace Z0.Parts
{
    public sealed class CmdActions : Part<CmdActions>
    {
    }
}

namespace Z0
{
    public static partial class XTend
    {
        [Op]
        public static GlobalCommands GlobalCommands(this IWfRuntime wf)
            => Z0.GlobalCommands.create(wf);
    }
}