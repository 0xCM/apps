//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Rules
{
    using System;
    using System.Runtime.CompilerServices;
    
    using static Root;
    using static core;

    partial struct rules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Replace<T> replace<T>(T src, T dst)
            where T : IEquatable<T>
                => new Replace<T>(src,dst);

        [Op, Closures(Closure)]
        public static Span<Replace<T>> replace<T>(Span<T> src, T dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = sys.alloc<Replace<T>>(count);
            ref var target = ref first(buffer);
            ref readonly var input = ref first(src);
            for(var i=0; i<count; i++)
                seek(target,i) = replace(skip(input,i), dst);
            return buffer;
        }
    }
}