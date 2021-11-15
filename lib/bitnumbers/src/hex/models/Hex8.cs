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
    using K = Hex8Seq;
    using W = W8;

    [DataType]
    public readonly struct Hex8 : IHexNumber<H,W,K>
    {
        public const uint StorageSize = PrimalSizes.U8;

        public K Value {get;}

        [MethodImpl(Inline)]
        public Hex8(K src)
            => Value = src;

        [MethodImpl(Inline)]
        public Hex8(byte src)
            => Value = (K)src;

        public const byte Width = 8;

        public const uint Count = 256;

        public const K KMin = K.x00;

        public const K KMax = K.xff;

        public const K KOne = K.x01;

        public static H Zero => KMin;

        public static H One => KOne;

        public static H Min => KMin;

        public static H Max => KMax;

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
            => new Hex8((Hex8Seq)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(H src)
            => (byte)src.Value;

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
        public static implicit operator H(Hex1Seq src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex2Seq src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex3Seq src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex4Seq src)
            => new H((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator H(Hex5Seq src)
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