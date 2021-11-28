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

    public readonly struct Hash64<T> : IHashCode<T,ulong>
        where T : unmanaged
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public Hash64(T value)
            => Value = value;

        public ulong Primitive
        {
            [MethodImpl(Inline)]
            get => u64(Value);
        }

        public string Format()
            => Primitive.ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash64(Hash64<T> src)
            => new Hash64(src.Primitive);
    }
}