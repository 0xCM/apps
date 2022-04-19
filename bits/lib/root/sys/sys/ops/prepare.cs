//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static ApiOpaqueClass;

    partial struct sys
    {
        [MethodImpl(Options), Opaque(PrepareMethod)]
        public static void prepare(RuntimeMethodHandle src)
            => proxy.prepare(src);

        [MethodImpl(Options), Opaque(PrepareDelegate)]
        public static void prepare(Delegate src)
            => proxy.prepare(src);
    }
}