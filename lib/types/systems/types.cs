//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly struct types
    {
        const NumericKind Closure = UnsignedInts;

        internal static string format(PrimalKind src)
            => src.ToString().ToLower();


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypeKind<K> kind<K>(K key, Identifier name)
            where K : unmanaged
                => new TypeKind<K>(key,name);

        [MethodImpl(Inline), Op]
        public static TypeKind kind(ulong key, Identifier @class, Identifier name)
            => new TypeKind(key, @class, name);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TypeKind untype<K>(TypeKind<K> src)
            where K : unmanaged
                => src;

    }
}