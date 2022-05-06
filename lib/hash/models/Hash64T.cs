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

    [DataType("hash<t:{0},w:64>")]
    public readonly struct Hash64<T> : IHashCode<T,ulong>
        where T : unmanaged
    {
        public readonly T Value;

        [MethodImpl(Inline)]
        public Hash64(T value)
            => Value = value;

        public ulong Primitive
        {
            [MethodImpl(Inline)]
            get => u64(Value);
        }

        T IHashCode<T>.Value
            => Value;

        public string Format()
            => uint64(Value).ToString("X");

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash64(Hash64<T> src)
            => new Hash64(src.Primitive);
    }
}