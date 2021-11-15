//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct @enum<E> : IEnum<E>, IEquatable<@enum<E>>
        where E : unmanaged, Enum
    {
        public E Literal {get;}

        [MethodImpl(Inline)]
        public @enum(E literal)
            => Literal = literal;

        public NativeTypeWidth Width
        {
            [MethodImpl(Inline)]
            get => core.width<E>();
        }

        [MethodImpl(Inline)]
        public bool Equals(E src)
            => emath.eq(Literal, src);

        [MethodImpl(Inline)]
        public bool Equals(@enum<E> src)
            => emath.eq(Literal, src.Literal);

        E IEnum<E>.Literal
            => Literal;
        public string Format()
            => $"{Literal}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator @enum<E>(E src)
            => new @enum<E>(src);

        [MethodImpl(Inline)]
        public static implicit operator E(@enum<E> src)
            => src.Literal;
    }
}