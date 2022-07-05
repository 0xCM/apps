//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
global using System;
global using System.Collections.Generic;
global using System.Collections.Concurrent;
global using System.Collections;

global using System.Reflection;
global using System.Reflection.Metadata;
global using System.Reflection.Emit;
global using System.Runtime.Intrinsics;
global using System.Runtime.CompilerServices;
global using System.Runtime.InteropServices;

global using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;
global using System.Diagnostics;
global using System.IO;

global using static Z0.Root;

[assembly: PartId(PartId.Lib)]

namespace Z0.Parts
{
    public sealed partial class Models : Part<Models>
    {

    }
}
