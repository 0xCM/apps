//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Hash32<T> : IHashCode<T,uint>
        where T : unmanaged
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public Hash32(T value)
            => Value = value;

        public uint Primitive
        {
            [MethodImpl(Inline)]
            get => core.u32(Value);
        }

        public string Format()
            => Primitive.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash32(Hash32<T> src)
            => new Hash32(src.Primitive);
    }
}