//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Vdsl
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct m512i<T>
        where T : unmanaged
    {
        Cell512<T> Data;

        [MethodImpl(Inline)]
        public m512i(Vector512<T> src)
            => Data = src;

        [MethodImpl(Inline)]
        public m512i(Cell512<T> src)
            => Data = src;

        public uint Width => 512;

        public uint CellWidth
        {
            [MethodImpl(Inline)]
            get => core.width<T>();
        }

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => Width/CellWidth;
        }

        [MethodImpl(Inline)]
        public ref T Cell(int i)
            => ref Data[i];

        public string Format()
            => string.Format("<{0}>", Data.ToVector().FormatHex());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator m512i<T>(Vector512<T> src)
            => new m512i<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator m512i<T>(T src)
            => gcpu.vbroadcast(w512,src);

        [MethodImpl(Inline)]
        public static implicit operator Vector512<T>(m512i<T> src)
            => src.Data;
    }
}