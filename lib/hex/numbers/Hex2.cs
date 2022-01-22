//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using H = Hex2;
    using K = Hex2Kind;
    using W = W2;

    [DataType("hex<w:2>", HexNumberKind.Hex2, ContentWidth, StorageWidth)]
    public readonly struct Hex2 : IHexNumber<H,W,K>
    {
        public K Value {get;}

        public const byte ContentWidth = 2;

        public const byte StorageWidth = 8;

        public const uint Count = 4;

        public const K KMin = K.x00;

        public const K KMax = K.x03;

        public const K KOne = K.x01;

        public static H Zero => KMin;

        public static H One => KOne;

        public static H Min => KMin;

        public static H Max => KMax;

        [MethodImpl(Inline)]
        public Hex2(K src)
            => Value = src & KMax;

        [MethodImpl(Inline)]
        public Hex2(byte src)
            => Value = (K)src & KMax;

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


        [MethodImpl(Inline)]
        public bool Equals(H src)
            => Value == src.Value;

        public override bool Equals(object src)
            => src is H c && Equals(c);

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Value;
        }

        public override int GetHashCode()
            => (int)Hash;

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
        public static implicit operator Hex3(Hex2 src)
            => new Hex3((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex4(Hex2 src)
            => new Hex4((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex5(Hex2 src)
            => new Hex5((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator Hex8(Hex2 src)
            => new Hex8((byte)src.Value);

        [MethodImpl(Inline)]
        public static implicit operator H(byte src)
            => new H((K)src);

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
        public static implicit operator H(Hex1Kind src)
            => new H((byte)src);
    }
}