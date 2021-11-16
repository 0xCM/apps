//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeKind<K> : ITextual
        where K : unmanaged
    {
        readonly K Value {get;}

        [MethodImpl(Inline)]
        public TypeKind(K src)
            => Value = src;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TypeKind<K>(K src)
            => new TypeKind<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator K(TypeKind<K> src)
            => src.Value;
    }
}