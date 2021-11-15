//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = Sizes;

    /// <summary>
    /// Specifies data size in bits
    /// </summary>
    public readonly struct BitWidth : IDataType<ulong>
    {
        /// <summary>
        /// Specifies a bit count
        /// </summary>
        public ulong Content {get;}

        /// <summary>
        /// Computes the bit-size of a parametric type
        /// </summary>
        /// <typeparam name="T">The type to measure</typeparam>
        [MethodImpl(Inline)]
        public static int measure<T>()
            => Unsafe.SizeOf<T>()*8;

        /// <summary>
        /// Computes the quotient q :=  a / bitsize[T] of an operand a and parametric type T
        /// </summary>
        /// <param name="a">The operand</param>
        /// <typeparam name="T">The parametric type from which a bit-width will be determined</typeparam>
        [MethodImpl(Inline)]
        public static int div<T>(int a)
            where T : unmanaged
                => a / (Unsafe.SizeOf<T>()*8);

        /// <summary>
        /// Computes the remainder r :=  a % bitsize[T] of an operand a and parametric type T
        /// </summary>
        /// <param name="a">The operand</param>
        /// <typeparam name="T">The parametric type from which a bit-width will be determined</typeparam>
        [MethodImpl(Inline)]
        public static int mod<T>(int a)
            where T : unmanaged
                => a % (Unsafe.SizeOf<T>()*8);

        [MethodImpl(Inline)]
        public BitWidth(sbyte bits)
            => Content = (ulong)bits;

        [MethodImpl(Inline)]
        public BitWidth(byte bits)
            => Content = bits;

        [MethodImpl(Inline)]
        public BitWidth(ushort bits)
            => Content = bits;

        [MethodImpl(Inline)]
        public BitWidth(int bits)
            => Content = (ulong)bits;

        [MethodImpl(Inline)]
        public BitWidth(uint bits)
            => Content = bits;

        [MethodImpl(Inline)]
        public BitWidth(long bits)
            => Content = (ulong)bits;

        [MethodImpl(Inline)]
        public BitWidth(ulong bits)
            => Content = bits;

        public Kb Kb
        {
            [MethodImpl(Inline)]
            get => api.kb(this);
        }

        public ByteSize Bytes
        {
            [MethodImpl(Inline)]
            get => Content/8;
        }
        public string Format()
            => Content.ToString();

        [MethodImpl(Inline)]
        public bool Equals(BitWidth b)
            => Content == b.Content;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Content;

        public override bool Equals(object obj)
            => obj is BitWidth x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator long(BitWidth src)
            => (long)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator ulong(BitWidth src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator uint(BitWidth src)
            => (uint)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(long src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(ulong src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(uint src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(DataWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator DataWidth(BitWidth src)
            => (DataWidth)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NativeTypeWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator NativeTypeWidth(BitWidth src)
            => (NativeTypeWidth)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NativeVectorWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(NumericWidth src)
            => new BitWidth((uint)src);

        [MethodImpl(Inline)]
        public static implicit operator NumericWidth(BitWidth src)
            => (NumericWidth)src.Content;

        [MethodImpl(Inline)]
        public static implicit operator BitWidth(ByteSize src)
            => new BitWidth(src.Content*8);

        [MethodImpl(Inline)]
        public static explicit operator ByteSize(BitWidth src)
            => src.Bytes;

        [MethodImpl(Inline)]
        public static explicit operator BitWidth(byte src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static explicit operator BitWidth(ushort src)
            => new BitWidth(src);

        [MethodImpl(Inline)]
        public static explicit operator int(BitWidth src)
            => (int)src.Content;

        [MethodImpl(Inline)]
        public static explicit operator byte(BitWidth src)
            => (byte)src.Content;

        [MethodImpl(Inline)]
        public static explicit operator ushort(BitWidth src)
            => (ushort)src.Content;

        [MethodImpl(Inline)]
        public static explicit operator double(BitWidth src)
            => src.Content;

        [MethodImpl(Inline)]
        public static bool operator ==(BitWidth a, BitWidth b)
            => a.Content == b.Content;

        [MethodImpl(Inline)]
        public static bool operator !=(BitWidth a, BitWidth b)
            => a.Content != b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator +(BitWidth a, BitWidth b)
            => a.Content + b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator -(BitWidth a, BitWidth b)
            => a.Content - b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator *(BitWidth a, BitWidth b)
            => a.Content * b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator /(BitWidth a, BitWidth b)
            => a.Content / b.Content;

        [MethodImpl(Inline)]
        public static BitWidth operator %(BitWidth a, BitWidth b)
            => a.Content % b.Content;

        /// <summary>
        /// The bit with no size
        /// </summary>
        public static BitWidth Empty
            => default;

        /// <summary>
        /// The bit with no size
        /// </summary>
        public static BitWidth Zero
            => default;
    }
}