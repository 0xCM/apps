//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Hashed
    {
        public readonly record struct Hash16<T> : IHashCode<T,ushort>
            where T : unmanaged, IEquatable<T>
        {
            public readonly T Value;

            [MethodImpl(Inline)]
            public Hash16(T value)
                => Value = value;

            public ushort Primitive
            {
                [MethodImpl(Inline)]
                get => u16(Value);
            }

            T IHashCode<T>.Value
                => Value;

            public string Format()
                => Primitive.ToString("X");

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Hash16(Hash16<T> src)
                => new Hash16(src.Primitive);
        }
    }
}