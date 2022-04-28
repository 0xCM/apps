//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = uint4_t;
    using K = System.Byte;
    using W = W4;

    [DataWidth(Width,AlignedWidth)]
    public readonly struct uint4_t
    {
        [Parser]
        public static Outcome parse(string src, out H dst)
        {
            var outcome = HexParser.parse8u(src, out var x);
            dst = new H((K)(x & 0b1111));
            return outcome;
        }

        [Parser]
        public static Outcome parse(ReadOnlySpan<char> src, out H dst)
        {
            var outcome = HexParser.parse8u(src, out var x);
            dst = new H((K)(x & 0b1111));
            return outcome;
        }

        public const byte Width = 4;

        const byte AlignedWidth = 8;

        public const byte MaxValue = Pow2.T04m1;

        public static H Zero => default;

        public static H One => new H(1, true);

        public static H Min => new H(0, true);

        public static H Max => new H(MaxValue, true);

        public static W W => default;

        public readonly K Value;

        [MethodImpl(Inline)]
        public uint4_t(K src)
            => Value = (byte)(src & MaxValue);

        [MethodImpl(Inline)]
        public uint4_t(K src, bool @unchecked)
            => Value = src;


        [MethodImpl(Inline)]
        public bool Equals(H src)
            => Value == src.Value;

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

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object src)
            => src is H c && Equals(c);

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(H src)
            => ((K)Value).CompareTo((K)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(K src)
            => new H(src);

        [MethodImpl(Inline)]
        public static implicit operator K(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(H src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint(H src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(H src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ulong(H src)
            => (ulong)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator H(ushort src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static explicit operator H(uint src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static explicit operator H(ulong src)
            => new H((byte)src);

    }
}