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

    partial struct gcalc
    {
        [MethodImpl(Inline), Mod, Closures(Floats)]
        public static Span<T> fmod<T>(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<T> dst)
            where T : unmanaged
        {
            var count = math.min(lhs.Length, dst.Length);
            ref readonly var a = ref first(lhs);
            ref readonly var b = ref first(rhs);
            ref var c = ref first(dst);
            for(var i = 0; i< count; i++)
                seek(c, i) = gfp.mod(skip(a, i), skip(b, i));
            return dst;
        }
    }
}