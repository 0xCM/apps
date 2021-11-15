//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(PrepareMethod)]
        public static void prepare(RuntimeMethodHandle src)
            => RuntimeHelpers.PrepareMethod(src);

        [MethodImpl(Options), Opaque(PrepareDelegate)]
        public static void prepare(Delegate src)
            => RuntimeHelpers.PrepareDelegate(src);
    }
}