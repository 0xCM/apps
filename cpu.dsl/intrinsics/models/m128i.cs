//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;
    using static Intrinsics;

    public struct m128i<T>
        where T : unmanaged
    {
        internal Cell128<T> Data;

        [MethodImpl(Inline)]
        public m128i(Vector128<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        public m128i(Cell128<T> src)
            => Data = src;

        public uint Width => 128;

        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => width<T>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Width/CellWidth;
        }

        public bit this[int i]
        {
            [MethodImpl(Inline)]
            get => Data.TestBit(i);

            [MethodImpl(Inline)]
            set => Data.SetBit(i,value);
        }

        public T this[int max, int min]
        {
            [MethodImpl(Inline)]
            get => Cells.bits(ref Data, max, min);
            [MethodImpl(Inline)]
            set => Cells.bits(ref Data, max, min) = value;
        }

        [MethodImpl(Inline)]
        public ref T Cell(int i)
            => ref Data[i];

        public string Format()
            => string.Format("<{0}>", Data.ToVector().FormatHex());

        public string Format(NumericBaseKind @base)
            => format(this, @base);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator m128i<T>(Vector128<T> src)
            => new m128i<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator m128i<T>(T src)
            => gcpu.vbroadcast(w128,src);

        [MethodImpl(Inline)]
        public static implicit operator Vector128<T>(m128i<T> src)
            => src.Data.ToVector();
    }
}