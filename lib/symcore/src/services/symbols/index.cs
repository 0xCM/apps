//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Symbols
    {
        public static SymIndex symindex(Type src)
            => SymIndexBuilder.create(src);

        [MethodImpl(Inline)]
        public static Symbols<E> index<E>()
            where E : unmanaged, Enum
                => SymCache<E>.get();
    }
}