//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Threading.Tasks;

global using static Z0.Root;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using SQ = Z0.SymbolicQuery;


[assembly: PartId(PartId.LlvmTools)]

namespace Z0.Parts
{
    public sealed class Llvm : Part<Llvm>
    {

    }
}
