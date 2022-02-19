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
global using System.Threading.Tasks;

global using static Z0.Root;
global using SQ = Z0.SymbolicQuery;
global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

[assembly: PartId(PartId.CpuDsl)]

namespace Z0.Parts
{
    public sealed class CpuDsl : Part<CpuDsl>
    {

    }
}