//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [DataType("m64")]
    public readonly struct Cell64 : IDataCell<Cell64,W64,ulong>
    {
        public ulong Content {get;}

        [MethodImpl(Inline)]
        public Cell64(ulong x0)
            => Content = x0;

        [MethodImpl(Inline)]
        public Cell64(long x0)
            => Content = (uint)x0;

        public CellKind Kind
            => CellKind.Cell64;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Cell32 Lo
        {
            [MethodImpl(Inline)]
            get => (uint)Content;
        }

        public Cell32 Hi
        {
            [MethodImpl(Inline)]
            get => (uint)(Content >> 32);
        }

        public Cell64 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        [MethodImpl(Inline)]
        public T As<T>()
            where T : struct
                => Numeric.force<T>(Content);

        [MethodImpl(Inline)]
        public bool Equals(ulong src)
            => Content == src;

        [MethodImpl(Inline)]
        public bool Equals(Cell64 src)
            => Content == src.Content;

        public string Format()
            => Content.FormatHex();

        public override string ToString()
            => Format();

         public override int GetHashCode()
            => Content.GetHashCode();

        public override bool Equals(object src)
            => src is Cell64 x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(int x0)
            => new Cell64(x0);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(long x0)
            => new Cell64(x0);

        [MethodImpl(Inline)]
        public static implicit operator Cell64(ulong x0)
            => new Cell64(x0);

        [MethodImpl(Inline)]
        public static implicit operator ulong(Cell64 x)
            => x.Content;

        [MethodImpl(Inline)]
        public static implicit operator Cell64(Cell32 x0)
            => new Cell64(x0.Content);

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Cell64 x)
            => (sbyte)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator short(Cell64 x)
            => (short)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Cell64 x)
            => (ushort)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator uint(Cell64 x)
            => (uint)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator int(Cell64 x)
            => (int)x.Content;

        [MethodImpl(Inline)]
        public static explicit operator long(Cell64 x)
            => (long)x.Content;

        [MethodImpl(Inline)]
        public static implicit operator Cell64((uint lo, uint hi) src)
            => new Cell64((((ulong)src.lo | ((ulong)src.hi << 32))));

        public static Cell64 Empty => default;
   }
}