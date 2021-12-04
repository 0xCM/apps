//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeAlias<A,B> : ITypeAlias<A,B>
        where A : unmanaged
        where B : unmanaged
    {
        public TypeKind<A> AliasType {get;}

        public TypeKind<B> BaseType {get;}

        [MethodImpl(Inline)]
        public TypeAlias(TypeKind<A> src, TypeKind<B> dst)
        {
            AliasType = src;
            BaseType = dst;
        }

        public static implicit operator TypeAlias(TypeAlias<A,B> src)
            => new TypeAlias(src.AliasType, src.BaseType);
    }
}