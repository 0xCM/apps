//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;

global using static Z0.Root;
global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;

[assembly: PartId(PartId.CmdShell)]
namespace Z0.Parts
{
    public sealed class CmdShell : Part<CmdShell>
    {
        [ModuleInitializer]
        internal static void Init()
        {

        }
    }
}

namespace Z0.Asm
{
    public static partial class XTend
    {
    }
}