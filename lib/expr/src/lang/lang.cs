//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly partial struct lang
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Atom<K> atom<K>(uint key, K value)
            where K : unmanaged
                => new Atom<K>(key, value);
    }
}