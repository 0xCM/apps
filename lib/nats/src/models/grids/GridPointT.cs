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

    /// <summary>
    /// Locates a cell in a grid with <typeparamref name='T'/> parametric coordinates
    /// </summary>
    public struct GridPoint<T> : IGridPoint<GridPoint<T>,T>
        where T : unmanaged
    {
        /// <summary>
        /// The cell row
        /// </summary>
        public T Row {get; private set;}

        /// <summary>
        /// The cell column
        /// </summary>
        public T Col {get; private set;}

        [MethodImpl(Inline)]
        public GridPoint(T row, T col)
        {
            Row = row;
            Col = col;
        }

        [MethodImpl(Inline)]
        public GridPoint<T> IncRow()
        {
            Row = add(Row,1);
            return this;
        }

        [MethodImpl(Inline)]
        public GridPoint<T> DecRow()
        {
            Row = sub(Row,1);
            return this;
        }

        [MethodImpl(Inline)]
        public GridPoint<T> IncCol()
        {
            Col = add(Col,1);
            return this;
        }

        [MethodImpl(Inline)]
        public GridPoint<T> DecCol()
        {
            Col = sub(Col,1);
            return this;
        }

        public string Format()
            => string.Format(GridPoint.RenderPattern, Row, Col);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static GridPoint<T> operator++(GridPoint<T> src)
            => src.IncRow();

        [MethodImpl(Inline)]
        public static GridPoint<T> operator--(GridPoint<T> src)
            => src.DecRow();

        [MethodImpl(Inline)]
        public static implicit operator GridPoint<T>(Pair<T> src)
            => new GridPoint<T>(src.Left, src.Right);

        [MethodImpl(Inline)]
        public static implicit operator GridPoint<T>((T row, T col) src)
            => new GridPoint<T>(src.row, src.col);

        [MethodImpl(Inline)]
        public static implicit operator GridPoint(GridPoint<T> src)
            => new GridPoint(u32(src.Row), u32(src.Col));

        public static GridPoint<T> Zero
            => new GridPoint<T>(default, default);
    }
}