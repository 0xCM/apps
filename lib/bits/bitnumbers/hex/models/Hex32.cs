//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using H = Hex32;
    using W = W32;
    using K = System.UInt32;

    [DataType]
    public readonly struct Hex32 : IHexNumber<H,W,K>
    {
        public const uint StorageSize = PrimalSizes.U32;

        public K Value {get;}

        [MethodImpl(Inline)]
        public Hex32(K offset)
            => Value = offset;

        public static W W
            => default;

        public bool IsZero
        {
             [MethodImpl(Inline)]
             get => Value == 0;
        }

        public bool IsNonZero
        {
             [MethodImpl(Inline)]
             get => Value != 0;
        }

        public Hex16 Lo
        {
            [MethodImpl(Inline)]
            get => (ushort)Value;
        }

        public Hex16 Hi
        {
            [MethodImpl(Inline)]
            get => (ushort)(Value >> 16);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public bool Equals(H src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is H a && Equals(a);

        [MethodImpl(Inline)]
        public int CompareTo(H src)
            => Value == src.Value ? 0 : Value < src.Value ? -1 : 1;

        [MethodImpl(Inline)]
        public string Format()
            => HexFormatter.format(Value, W, false);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        [MethodImpl(Inline)]
        public static implicit operator H(K src)
            => new H(src);

        [MethodImpl(Inline)]
        public static implicit operator K(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(int src)
            => new H((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator ulong(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Address32(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(Address32 src)
            => new H(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator H(MemoryAddress src)
            => new H((uint)src.Location);

        [MethodImpl(Inline)]
        public static H operator+(H x, K y)
            => new H((K)(x.Value + y));

        [MethodImpl(Inline)]
        public static bool operator <(H a, H b)
            => a.Value < b.Value;

        [MethodImpl(Inline)]
        public static bool operator >(H a, H b)
            => a.Value > b.Value;

        [MethodImpl(Inline)]
        public static bool operator <=(H a, H b)
            => a.Value <= b.Value;

        [MethodImpl(Inline)]
        public static bool operator >=(H a, H b)
            => a.Value >= b.Value;

        [MethodImpl(Inline)]
        public static bool operator==(H x, H y)
            => x.Value == y.Value;

        [MethodImpl(Inline)]
        public static bool operator!=(H x, H y)
            => x.Value != y.Value;

        public static H Zero => default;

        public static H Max => K.MaxValue;
    }
}