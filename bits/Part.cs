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
global using CallerName = System.Runtime.CompilerServices.CallerMemberNameAttribute;
global using CallerFile = System.Runtime.CompilerServices.CallerFilePathAttribute;
global using CallerLine = System.Runtime.CompilerServices.CallerLineNumberAttribute;

[assembly: PartId(PartId.Bits)]

namespace Z0.Parts
{
    public sealed partial class Bits : Part<Bits>
    {

    }
}

namespace Z0
{
    using static Root;

    [ApiHost]
    public static partial class XTend
    {
        const NumericKind Closure = Root.UnsignedInts;

        [Op]
        public static BitfieldServices Bitfields(this IWfRuntime wf)
            => Z0.BitfieldServices.create(wf);

    }


    partial struct Msg
    {
        const NumericKind Closure = Root.UnsignedInts;


    }
}