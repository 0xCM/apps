//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct bit
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static void fill<T>(in T src, Span<bit> dst)
            where T : struct
        {
            var size = size<T>();
            var count = min(size, dst.Length);
            if(count == 0)
                return;

            ref var input = ref @as<T,byte>(src);
            ref var output = ref @as<bit,ulong>(first(dst));
            for(var i=0u; i<size; i++)
                seek(output, i) = unpack(skip(input,i));
        }
    }
}