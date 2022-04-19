//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static System.Runtime.CompilerServices.Unsafe;

    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte seek8i<T>(in T src, ulong count)
            => ref add(@as<T,sbyte>(edit(src)), (int)count);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte seek8i<T>(Span<T> src, ulong count)
            => ref Add(ref As<T,sbyte>(ref first(src)), (int)count);
    }
}