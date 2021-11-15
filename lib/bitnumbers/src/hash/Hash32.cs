//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Hash32 : IHashCode<uint,uint>, IDataTypeComparable<Hash32>
    {
        public uint Value {get;}

        [MethodImpl(Inline)]
        public Hash32(uint value)
            => Value = value;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString("X");

        public override string ToString()
            => Format();

        public uint Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public bool Equals(Hash32 src)
            => Value.Equals(src.Value);

        [MethodImpl(Inline)]
        public int CompareTo(Hash32 src)
            => Value.CompareTo(src.Value);

        public override bool Equals(object src)
            => src is Hash32 h && Equals(h);

        public override int GetHashCode()
            => (int)Value;

        [MethodImpl(Inline)]
        public static implicit operator Hash32(uint src)
            => new Hash32(src);

        [MethodImpl(Inline)]
        public static implicit operator int(Hash32 src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static implicit operator uint(Hash32 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Hash32(int src)
            => new Hash32((uint)src);

        [MethodImpl(Inline)]
        public static uint operator %(Hash32 src, uint m)
            => src.Value % m;
    }
}