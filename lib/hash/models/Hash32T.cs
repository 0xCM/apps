//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [DataType("hash<t:{0},w:32>")]
    public readonly struct Hash32<T> : IHashCode<T,uint>
        where T : unmanaged
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