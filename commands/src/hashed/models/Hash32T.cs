//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Hashed
    {
        public readonly record struct Hash32<T> : IHashCode<T,uint>
            where T : unmanaged, IEquatable<T>
        {
            public readonly T Value;

            [MethodImpl(Inline)]
            public Hash32(T value)
                => Value = value;

            public uint Primitive
            {
                [MethodImpl(Inline)]
                get => u32(Value);
            }

            T IHashCode<T>.Value
                => Value;

            public string Format()
                => uint32(Value).ToString("X");

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Hash32(Hash32<T> src)
                => new Hash32(src.Primitive);
        }
    }
}