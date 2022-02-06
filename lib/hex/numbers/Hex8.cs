//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using H = Hex8;
    using K = Hex8Kind;
    using W = W8;

    [DataType("hex<w:8>", HexNumberKind.Hex8, ContentWidth, StorageWidth)]
    public readonly struct Hex8 : IHexNumber<H,W,K>
    {
        public const byte ContentWidth = 8;

        public const byte StorageWidth = 8;

        public const K KMin = K.x00;

        public const K KMax = K.xff;

        public const K KOne = K.x01;

        public static H Zero => KMin;

        public static H One => KOne;

        public static H Min => KMin;

        public static H Max => KMax;

        [Parser]
        public static Outcome parse(string src, out Hex8 dst)
        {
            var outcome = Hex.parse8u(src, out var x);
            dst = x;
            return outcome;
        }

        public K Value {get;}

        [MethodImpl(Inline)]
        public Hex8(K src)
            => Value = src;

        [MethodImpl(Inline)]
        public Hex8(byte src)
            => Value = (K)src;

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

        public Hex4 Lo
        {
            [MethodImpl(Inline)]
            get => (byte)((byte)Value & 0xF);
        }

        public Hex4 Hi
        {
            [MethodImpl(Inline)]
            get => (byte)((byte)Value >> 4);
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

        public string Text
        {
            [MethodImpl(Inline)]
            get => ((byte)Value).FormatHex(specifier:false, zpad:true);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Text;

        public string Format(bool zpad = true, bool prespec = false, bool uppercase = false)
            => ((byte)Value).FormatHex(zpad:zpad, prespec:prespec, uppercase:uppercase);

        public override string ToString()
            => Text;

        [MethodImpl(Inline)]
        public int CompareTo(H src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(K src)
            => new H(src);

        [MethodImpl(Inline)]
        public static implicit operator K(H src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator H(byte src)
            => new Hex8((Hex8Kind)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(H src)
            => (byte)src.Value;

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
        public static implicit operator H(Hex1Kind src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex2Kind src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex3Kind src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex4Kind src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex5Kind src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Address8 src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator Address8(H src)
            => new Address8(src);
        public static H MaxValue
        {
            [MethodImpl(Inline)]
            get =>  byte.MaxValue;
        }
    }
}