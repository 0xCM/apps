//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections;
global using System.Collections.Concurrent;
global using System.Reflection;
global using System.Diagnostics;
global using System.Reflection.Metadata;
global using System.Reflection.Metadata.Ecma335;
global using System.Reflection.PortableExecutable;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Threading;
global using System.Threading.Tasks;
global using System.IO;

global using static Z0.Root;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

[assembly: PartId(PartId.Symbolics)]

namespace Z0.Parts
{
    public sealed class Symbolics : Part<Symbolics>
    {

    }
}

namespace Z0
{
    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static bool Test<E>(this E src, E flag)
            where E : unmanaged, Enum
                => (core.bw64(src) & core.bw64(flag)) != 0;

    }
}
