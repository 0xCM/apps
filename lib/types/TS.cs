//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly partial struct TS
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static TypeAlias<A,B> alias<A,B>(TypeKind<A> a, TypeKind<B> b)
            where A : unmanaged
            where B : unmanaged
                => new TypeAlias<A,B>(a,b);

        [MethodImpl(Inline), Op]
        public static TypeAlias alias(TypeKind a, TypeKind b)
            => new TypeAlias(a,b);
    }
}