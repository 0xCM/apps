//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitNumbers;

    using U = uint8b;
    using W = W8;
    using K = BitSeq8;
    using T = System.Byte;
    using N = N8;

    /// <summary>
    /// Represents the value of a type-level octet and thus is an integer in the range [0,255]
    /// </summary>
    [DataType("u<w:8>", Width, 8)]
    public readonly struct uint8b : IBitNumber<U,W,K,T>
    {
        public const byte BitCount = 8;

        internal readonly T data;

        [MethodImpl(Inline)]
        public uint8b(byte x)
            => data = x;

        [MethodImpl(Inline)]
        public uint8b(K x)
            => data =(byte)x;

        [MethodImpl(Inline)]
        internal uint8b(BitState src)
            => data = (byte)src;

        /// <summary>
        /// Queries the state of an index-identified bit
        /// </summary>
        public bit this[byte pos]
        {
            [MethodImpl(Inline)]
            get => test(this, pos);
        }

        public K Kind
        {
            [MethodImpl(Inline)]
            get => (K) data;
        }

        public T Content
        {
            [MethodImpl(Inline)]
            get => data;
        }

        public bool IsZero
        {
            [MethodImpl(Inline)]
            get => data == 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => data != 0;
        }

        /// <summary>
        /// Specifies whether the current value is the maximum value
        /// </summary>
        public bool IsMax
        {
            [MethodImpl(Inline)]
            get => data == MaxValue;
        }

        /// <summary>
        /// Specifies whether the current value is the minimum value
        /// </summary>
        public bool IsMin
        {
            [MethodImpl(Inline)]
            get => data == MinLiteral;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => data;
        }

        public uint4 Lo
        {
            [MethodImpl(Inline)]
            get => lo(this);
        }

        public uint4 Hi
        {
            [MethodImpl(Inline)]
            get => hi(this);
        }

        [MethodImpl(Inline)]
        public uint8b WithLo(uint4 src)
            => movlo(src, this);

        [MethodImpl(Inline)]
        public uint8b WithHi(uint4 src)
            => movhi(src, this);

        [MethodImpl(Inline)]
        public bool Equals(U y)
            => data == y.data;


        public override int GetHashCode()
            => (int)Hash;

        public override bool Equals(object y)
            => data.Equals(y);

         public string Format()
             => format(this);

        public string Format(BitFormat config)
            => format(this,config);

        public override string ToString()
            => Format();

       [MethodImpl(Inline)]
        public static implicit operator U(K src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator K(U src)
            => (K)src.data;

        [MethodImpl(Inline)]
        public static U @bool(bool x)
            => x ? One : Zero;

        [MethodImpl(Inline)]
        public static bool operator true(U x)
            => x.data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(U x)
            => x.data == 0;

        [MethodImpl(Inline)]
        public static explicit operator bit(U src)
            => new bit(src.data & 1);

        [MethodImpl(Inline)]
        public static explicit operator U(bit src)
            => (byte)src;

        [MethodImpl(Inline)]
        public static implicit operator U(byte src)
            => new U(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(U src)
            => (sbyte)src.data;

        [MethodImpl(Inline)]
        public static explicit operator short(U src)
            => (short)src.data;

        [MethodImpl(Inline)]
        public static implicit operator ushort(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static explicit operator int(U src)
            => (int)src.data;

        [MethodImpl(Inline)]
        public static implicit operator uint(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static explicit operator long(U src)
            => (long)src.data;

        [MethodImpl(Inline)]
        public static implicit operator ulong(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static implicit operator float(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static implicit operator double(U src)
            => src.data;

        [MethodImpl(Inline)]
        public static U operator == (U x, U y)
            => @bool(x.data == y.data);

        [MethodImpl(Inline)]
        public static U operator != (U x, U y)
            => @bool(x.data != y.data);

        [MethodImpl(Inline)]
        public static U operator + (U x, U y)
            => wrap(x.data + y.data);

        [MethodImpl(Inline)]
        public static U operator - (U x, U y)
            => wrap(x.data - y.data);

        [MethodImpl(Inline)]
        public static U operator * (U x, U y)
            => wrap(x.data * y.data);

        [MethodImpl(Inline)]
        public static U operator / (U x, U y)
            => wrap(x.data / y.data);

        [MethodImpl(Inline)]
        public static U operator % (U x, U y)
            => wrap(x.data % y.data);

        [MethodImpl(Inline)]
        public static U operator < (U x, U y)
            => @bool(x.data < y.data);

        [MethodImpl(Inline)]
        public static U operator <= (U x, U y)
            => @bool(x.data <= y.data);

        [MethodImpl(Inline)]
        public static U operator > (U x, U y)
            => @bool(x.data > y.data);

        [MethodImpl(Inline)]
        public static U operator >= (U x, U y)
            => @bool(x.data >= y.data);

        [MethodImpl(Inline)]
        public static U operator & (U x, U y)
            => (U)(x.data & y.data);

        [MethodImpl(Inline)]
        public static U operator | (U x, U y)
            => wrap(x.data | y.data);

        [MethodImpl(Inline)]
        public static U operator ^ (U x, U y)
            => wrap(x.data ^ y.data);

        [MethodImpl(Inline)]
        public static U operator >> (U x, int y)
            => wrap(x.data >> y);

        [MethodImpl(Inline)]
        public static U operator << (U x, int y)
            => wrap(x.data << y);

        [MethodImpl(Inline)]
        public static U operator ~ (U src)
            => wrap(~ src.data);

        [MethodImpl(Inline)]
        public static U operator - (U src)
            => wrap(~src.data + 1);

        [MethodImpl(Inline)]
        public static U operator -- (U src)
            => dec(src);

        [MethodImpl(Inline)]
        public static U operator ++ (U src)
            => inc(src);

        public const T MinLiteral = 0;

        public const T MaxValue = byte.MaxValue;

        /// <summary>
        /// Specifies the bit-width represented by <see cref='U'/>
        /// </summary>
        public const byte Width = 8;

        public const uint Mod = 256;

        public static W W => default;

        public static N N => default;

        public static U Zero => 0;

        public static U One => 1;

        /// <summary>
        /// Specifies the minimum <see cref='U'/> value
        /// </summary>
        public static U Min
        {
            [MethodImpl(Inline)]
            get => new U(MinLiteral);
        }

        /// <summary>
        /// Specifies the maximum <see cref='U'/> value
        /// </summary>
        public static U Max
        {
            [MethodImpl(Inline)]
            get => new U(MaxValue);
        }

        public Span<bit> Bits
        {
            [MethodImpl(Inline)]
            get => bits(this);
        }

        [MethodImpl(Inline)]
        static U wrap(int x)
            => new U((byte)x);
    }
}