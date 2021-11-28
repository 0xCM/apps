//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct Hash8<T> : IHashCode<T,byte>
        where T : unmanaged
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public Hash8(T value)
            => Value = value;

        public byte Primitive
        {
            [MethodImpl(Inline)]
            get => u8(Value);
        }

        public string Format()
            => Primitive.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash8(Hash8<T> src)
            => new Hash8(src.Primitive);

        [MethodImpl(Inline)]
        public static implicit operator Hash<T,byte>(Hash8<T> src)
            => new Hash<T,byte>(src.Value);
    }
}