//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using T = System.Byte;

    /// <summary>
    /// Represents an encoded instruction byte
    /// </summary>
    public struct AsmByte : IDataTypeComparable<AsmByte>
    {
        public T Content;

        public T Value
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        [MethodImpl(Inline)]
        public AsmByte(T value)
            => Content = value;

        [MethodImpl(Inline)]
        public string Format()
            => Content.FormatHex(specifier:false);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Content.GetHashCode();

        public override bool Equals(object src)
            => src is AsmByte a && Equals(a);

        public uint4 Lo
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public uint4 Hi
        {
            [MethodImpl(Inline)]
            get => (uint4)(Content >> 4);
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmByte src)
            => Content.CompareTo(src.Content);

        [MethodImpl(Inline)]
        public bool Equals(AsmByte src)
            => Content.Equals(src.Content);

        [MethodImpl(Inline)]
        public static bit operator == (AsmByte a, AsmByte b)
            => a.Content == b.Content;

        [MethodImpl(Inline)]
        public static bit operator != (AsmByte a, AsmByte b)
            => a.Content != b.Content;

        [MethodImpl(Inline)]
        public static bit operator < (AsmByte a, AsmByte b)
            => a.Content < b.Content;

        [MethodImpl(Inline)]
        public static bit operator <= (AsmByte a, AsmByte b)
            => a.Content <= b.Content;

        [MethodImpl(Inline)]
        public static bit operator > (AsmByte a, AsmByte b)
            => a.Content > b.Content;

        [MethodImpl(Inline)]
        public static bit operator >= (AsmByte a, AsmByte b)
            => a.Content >= b.Content;

        [MethodImpl(Inline)]
        public static AsmByte operator & (AsmByte a, AsmByte b)
            => (AsmByte)(a.Content & b.Content);

        [MethodImpl(Inline)]
        public static AsmByte operator | (AsmByte a, AsmByte b)
            => (AsmByte)(a.Content | b.Content);

        [MethodImpl(Inline)]
        public static AsmByte operator ^ (AsmByte a, AsmByte b)
            => (AsmByte)(a.Content ^ b.Content);

        [MethodImpl(Inline)]
        public static AsmByte operator >> (AsmByte a, int offset)
            => (AsmByte)(a.Content >> offset);

        [MethodImpl(Inline)]
        public static AsmByte operator << (AsmByte a, int offset)
            => (AsmByte)(a.Content << offset);

        [MethodImpl(Inline)]
        public static AsmByte operator ~ (AsmByte x)
            => (AsmByte)~ x.Content;

        [MethodImpl(Inline)]
        public static implicit operator AsmByte(T src)
            => new AsmByte(src);
    }
}