//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct relations
    {
        [Op, Closures(Closure)]
        public static ArrowType<T> type<T>()
            => new ArrowType<T>(typeof(T), typeof(T));

        [MethodImpl(Inline), Op]
        public static ArrowType type(Type src, Type dst)
            => new ArrowType(src,dst);

        [MethodImpl(Inline), Op]
        public static ArrowType type(Type src, Type dst, Type kind)
            => new ArrowType(src,dst, kind);

        [MethodImpl(Inline)]
        public static ArrowType<S,T> type<S,T>()
            => new ArrowType<S,T>(typeof(S), typeof(T));

        [MethodImpl(Inline)]
        public static ArrowType<S,T,K> type<S,T,K>()
            where K : unmanaged
                => new ArrowType<S,T,K>(typeof(S), typeof(T), typeof(K));
    }
}