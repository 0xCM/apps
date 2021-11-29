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

    using api = Grids;

    public readonly ref struct GridView<T>
    {
        readonly ReadOnlySpan<T> Data;

        public GridDim Dim {get;}

        [MethodImpl(Inline)]
        public GridView(GridDim dim, ReadOnlySpan<T> data)
        {
            Dim = dim;
            Data = data;
        }

        ref readonly T First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        [MethodImpl(Inline)]
        public ref readonly T Cell(uint row, uint col)
            => ref seek(First, api.lineraize(Dim, (row, col)));

        [MethodImpl(Inline)]
        public ref readonly T Cell(GridPoint point)
            => ref seek(First, api.lineraize(Dim, point));

        public ref readonly T this[uint row, uint col]
        {
            [MethodImpl(Inline)]
            get => ref Cell(row,col);
        }
    }
}