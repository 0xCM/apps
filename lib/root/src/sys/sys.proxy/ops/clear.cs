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
        [MethodImpl(Options), Opaque(ClearSpan), Closures(Closure)]
        public static Span<T> clear<T>(Span<T> src)
        {
            src.Clear();
            return src;
        }

        [MethodImpl(Options), Opaque(ClearSpan), Closures(Closure)]
        public static T[] clear<T>(T[] dst)
        {
            if(dst == null)
                return empty<T>();
            else
            {
                Array.Fill(dst, default(T));
                return dst;
            }
        }
    }
}