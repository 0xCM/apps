//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Scalars;

    public readonly record struct Hash64<T>
        where T : unmanaged, IEquatable<T>
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash64(T value)
            => Value = value;

        public ulong Primitive
        {
            [MethodImpl(Inline)]
            get => uint64(Value);
        }

        public string Format()
            => uint64(Value).ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash64(Hash64<T> src)
            => new Hash64(src.Primitive);
    }

}