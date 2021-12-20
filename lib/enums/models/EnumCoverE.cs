//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct EnumCover<E> : IEnumCover<E>
        where E : unmanaged, Enum
    {
        public E Value {get;}

        [MethodImpl(Inline)]
        public EnumCover(E value)
        {
            Value = value;
        }

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public static implicit operator EnumCover<E>(E src)
            => new EnumCover<E>(src);

        public static implicit operator E(EnumCover<E> src)
            => src.Value;
    }
}