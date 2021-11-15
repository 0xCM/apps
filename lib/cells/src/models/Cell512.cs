//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;

    using F = Cell512;

    [DataType("m512")]
    public readonly struct Cell512  : IDataCell<Cell512,W512,Vector512<ulong>>
    {
        readonly Cell256 X0;

        readonly Cell256 X1;

        public CellKind Kind
            => CellKind.Cell512;

        public Vector512<ulong> Content
        {
            [MethodImpl(Inline)]
            get => (X0, X1);
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Cell256 Lo
        {
            [MethodImpl(Inline)]
            get => X0;
        }

        public Cell256 Hi
        {
            [MethodImpl(Inline)]
            get => X1;
        }

        public int BitWidth => 512;

        public int Size => 64;

        public Cell512 Zero
        {
            [MethodImpl(Inline)]
            get => Empty;
        }

        [MethodImpl(Inline)]
        public Cell512(Cell256 x0, Cell256 x1)
        {
            X0 = x0;
            X1 = x1;
        }

        [MethodImpl(Inline)]
        public Cell512(in Vector512<ulong> src)
        {
            X0 = src.Lo;
            X1 = src.Hi;
        }

        [MethodImpl(Inline)]
        public Cell512(ByteBlock64 src)
        {
            var v = src.Vector<ulong>();
            X0 = v.Lo;
            X1 = v.Hi;
        }

        [MethodImpl(Inline)]
        public static Cell512 init<T>(in Vector512<T> src)
            where T : unmanaged
                => new Cell512(src.As<ulong>());

        public string Format()
            => sys.array(X0, X1).FormatList();

        [MethodImpl(Inline)]
        public bool Equals(Cell512 src)
            => X0.Equals(src.X0) && X1.Equals(src.X1);

        [MethodImpl(Inline)]
        public bool Equals(Vector512<ulong> src)
            => Content.Equals(src);

        public override int GetHashCode()
            => HashCode.Combine(X0,X1);

        public override bool Equals(object src)
            => src is Cell512 x && Equals(x);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public T As<T>()
            where T : struct
                => @as<F,T>(this);

        [MethodImpl(Inline)]
        public Vector512<T> ToVector<T>()
            where T : unmanaged
                => Unsafe.As<Cell512,Vector512<T>>(ref Unsafe.AsRef(this));

        [MethodImpl(Inline)]
        public Vector256<T> LoVector<T>()
            where T : unmanaged
                => @as<Cell256,Vector256<T>>(Lo);

        [MethodImpl(Inline)]
        public Vector256<T> HiVector<T>()
            where T : unmanaged
                => @as<Cell256,Vector256<T>>(Hi);

        [MethodImpl(Inline)]
        public static implicit operator Cell512((Cell256 x0, Cell256 x1) x)
            => new Cell512(x.x0,x.x1);

        [MethodImpl(Inline)]
        public static implicit operator Cell512(in Vector512<byte> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell512(in Vector512<ushort> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell512(in Vector512<uint> x)
            => init(x);

        [MethodImpl(Inline)]
        public static implicit operator Cell512(in Vector512<ulong> x)
            => init(x);

        public static Cell512 Empty => default;
    }
}