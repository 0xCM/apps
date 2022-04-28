//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Defines potential values for machine-aligned data widths
    /// </summary>
    public readonly struct Aligned : IComparable<Aligned>, IEquatable<Aligned>
    {
        readonly Log2x64 Code;

        public static Aligned W8 => new Aligned(Log2x64.L3);

        public static Aligned W16 => new Aligned(Log2x64.L4);

        public static Aligned W32 => new Aligned(Log2x64.L5);

        public static Aligned W64 => new Aligned(Log2x64.L6);

        public static Aligned W128 => new Aligned(Log2x64.L7);

        public static Aligned W256 => new Aligned(Log2x64.L8);

        public static Aligned W512 => new Aligned(Log2x64.L9);

        public static Aligned W1024 => new Aligned(Log2x64.L10);

        [MethodImpl(Inline)]
        public Aligned(Log2x2 src)
        {
            Code = (Log2x64)src;
        }

        [MethodImpl(Inline)]
        public Aligned(Log2x3 src)
        {
            Code = (Log2x64)src;
        }

        [MethodImpl(Inline)]
        public Aligned(Log2x4 src)
        {
            Code = (Log2x64)src;
        }

        [MethodImpl(Inline)]
        public Aligned(Log2x8 src)
        {
            Code = (Log2x64)src;
        }

        [MethodImpl(Inline)]
        public Aligned(Log2x16 src)
        {
            Code = (Log2x64)src;
        }

        [MethodImpl(Inline)]
        public Aligned(Log2x32 src)
        {
            Code = (Log2x64)src;
        }

        [MethodImpl(Inline)]
        public Aligned(Log2x64 src)
        {
            Code = src;
        }

        [MethodImpl(Inline)]
        public Aligned(Pow2x2 src)
        {
            Code = (Log2x64)Pow2.log(src);
        }

        [MethodImpl(Inline)]
        public Aligned(Pow2x3 src)
        {
            Code = (Log2x64)Pow2.log(src);
        }

        [MethodImpl(Inline)]
        public Aligned(Pow2x4 src)
        {
            Code = (Log2x64)Pow2.log(src);
        }

        [MethodImpl(Inline)]
        public Aligned(Pow2x8 src)
        {
            Code = (Log2x64)Pow2.log(src);
        }

        [MethodImpl(Inline)]
        public Aligned(Pow2x16 src)
        {
            Code = (Log2x64)Pow2.log(src);
        }

        [MethodImpl(Inline)]
        public Aligned(Pow2x32 src)
        {
            Code = (Log2x64)Pow2.log(src);
        }

        [MethodImpl(Inline)]
        public Aligned(Pow2x64 src)
        {
            Code = Pow2.log(src);
        }

        [MethodImpl(Inline)]
        public Aligned(ByteSize src)
        {
            Code = (Log2x64)Pow2.log((byte)((byte)src*8));
        }

        [MethodImpl(Inline)]
        public Aligned(ulong width)
        {
            Code = (Log2x64)Pow2.log(width);
        }

        [MethodImpl(Inline)]
        public Aligned(byte code)
        {
            Code = (Log2x64)code;
        }

        public byte Log2
        {
            [MethodImpl(Inline)]
            get => (byte)Code;
        }

        public ulong Width
        {
            [MethodImpl(Inline)]
            get => Pow2.pow((byte)Code);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => ((ulong)Width/8);
        }

        [MethodImpl(Inline)]
        public int CompareTo(Aligned src)
            => Log2.CompareTo(src.Log2);

        [MethodImpl(Inline)]
        public bool Equals(Aligned src)
            => Code == src.Code;

        public override bool Equals([NotNullWhen(true)] object src)
            => src is Aligned a && Equals(a);

        public override int GetHashCode()
            => Log2;

        public string Format()
            => Width.ToString();

        public string Format(FormatKind kind)
            => kind switch
            {
                FormatKind.Pow2 => $"2^{Log2}",
                FormatKind.Log2=> $"log({Width})",
                _ => Format()
            };

        public enum FormatKind
        {
            Default,

            Pow2,

            Log2,
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Aligned(ulong src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(ByteSize src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Log2x2 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Log2x3 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Log2x4 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Log2x8 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Log2x16 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Log2x32 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Log2x64 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Pow2x2 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Pow2x3 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Pow2x4 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Pow2x8 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Pow2x16 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Pow2x32 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static implicit operator Aligned(Pow2x64 src)
            => new Aligned(src);

        [MethodImpl(Inline)]
        public static explicit operator byte(Aligned src)
            => src.Log2;

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(Aligned src)
            => src.Size;

        [MethodImpl(Inline)]
        public static explicit operator BitWidth(Aligned src)
            => src.Width;

        [MethodImpl(Inline)]
        public static implicit operator ulong(Aligned src)
            => src.Width;

        [MethodImpl(Inline)]
        public static implicit operator Log2x2(Aligned src)
            => (Log2x2)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x3(Aligned src)
            => (Log2x3)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x4(Aligned src)
            => (Log2x4)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x8(Aligned src)
            => (Log2x8)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x16(Aligned src)
            => (Log2x16)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x32(Aligned src)
            => (Log2x32)src.Code;

        [MethodImpl(Inline)]
        public static implicit operator Log2x64(Aligned src)
            => src.Code;

        [MethodImpl(Inline)]
        public static bool operator ==(Aligned a, Aligned b)
            => a.Code == b.Code;

        [MethodImpl(Inline)]
        public static bool operator !=(Aligned a, Aligned b)
            => a.Code != b.Code;

        [MethodImpl(Inline)]
        public static BitMask operator |(Aligned a, Aligned b)
            => BitMask.mask(a.Width | b.Width);

        [MethodImpl(Inline)]
        public static BitMask operator ^(Aligned a, Aligned b)
            => BitMask.mask(a.Width ^ b.Width);

        [MethodImpl(Inline)]
        public static BitMask operator &(Aligned a, Aligned b)
            => BitMask.mask(a.Width & b.Width);

        [MethodImpl(Inline)]
        public static BitMask operator ~(Aligned a)
            => BitMask.mask(~a.Width);

        [MethodImpl(Inline)]
        public static BitMask operator <<(Aligned a, int count)
            => BitMask.mask(a.Width << count);

        [MethodImpl(Inline)]
        public static BitMask operator >>(Aligned a, int count)
            => BitMask.mask(a.Width >> count);
    }
}