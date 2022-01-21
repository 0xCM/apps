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

    partial struct Rules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReplaceRule<T> replace<T>(T src, T dst)
            where T : IEquatable<T>
                => new ReplaceRule<T>(src,dst);

        [Op, Closures(Closure)]
        public static Replacements<T> replace<T>(ReadOnlySpan<T> src, T dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = sys.alloc<ReplaceRule<T>>(count);
            ref var target = ref first(buffer);
            ref readonly var input = ref first(src);
            for(var i=0; i<count; i++)
                seek(target,i) = new ReplaceRule<T>(skip(input,i), dst);
            return buffer;
        }
    }
}