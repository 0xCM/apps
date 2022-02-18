//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using H = Hex64;
    using W = W64;
    using K = System.UInt64;

    [DataType("hex<w:64>", HexNumberKind.Hex64, ContentWidth, StorageWidth)]
    public readonly struct Hex64 : IHexNumber<H,W,K>
    {
        [Parser]
        public static Outcome parse(string src, out Hex64 dst)
        {
            var outcome = HexParser.parse64u(src, out var x);
            dst = x;
            return outcome;
        }

        public const byte ContentWidth = 64;

        public const byte StorageWidth = 64;

        public K Value {get;}

        [MethodImpl(Inline)]
        public Hex64(K offset)
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

        public Hex32 Lo
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public Hex32 Hi
        {
            [MethodImpl(Inline)]
            get => (uint)(Value >> 32);
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.calc(Value);
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

        public string Format(bool zpad = true, bool prespec = false, bool uppercase = false)
            => ((ulong)Value).FormatHex(zpad:zpad, prespec:prespec, uppercase:uppercase);


        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

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
        public static implicit operator Address64(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(Address64 src)
            => new H(src.Location);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(H src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(H src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator short(H src)
            => (short)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator ushort(H src)
            => (ushort)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator int(H src)
            => (int)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator uint(H src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator long(H src)
            => (long)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator H(MemoryAddress src)
            => new H((uint)src.Location);

        public static H Zero => default;

        public static H Max => K.MaxValue;
    }
}