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
global using SQ = Z0.SymbolicQuery;

[assembly: PartId(PartId.XedShell)]

namespace Z0.Parts
{
    using static core;

    public sealed class XedShell : Part<XedShell>
    {
        [ModuleInitializer]
        internal static void Init()
        {
            AppData.init();
        }

    }
}