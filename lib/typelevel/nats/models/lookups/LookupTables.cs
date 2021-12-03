//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct LookupTables
    {
        [MethodImpl(Inline), Op]
        internal static uint data(LookupKey src)
            => @as<LookupKey,uint>(src);

        const NumericKind Closure = UnsignedInts;
    }
}