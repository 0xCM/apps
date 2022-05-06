//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [DataType("hash<t:{0},w:8>")]
    public readonly struct Hash8<T> : IHashCode<T,byte>
        where T : unmanaged
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash8(T value)
            => Value = value;

        public byte Primitive
        {
            [MethodImpl(Inline)]
            get => u8(Value);
        }

        T IHashCode<T>.Value
            => Value;

        public string Format()
            => u8(Value).ToString("X");

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