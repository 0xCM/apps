//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Locates a cell within a grid
    /// </summary>
    [StructLayout(StructLayout, Pack=1)]
    public readonly record struct GridPoint : IGridPoint<GridPoint>
    {
        internal const string RenderPattern = "({0},{1})";

        /// <summary>
        /// The cell row
        /// </summary>
        public readonly uint Row;

        /// <summary>
        /// The cell column
        /// </summary>
        public readonly uint Col;

        [MethodImpl(Inline)]
        public GridPoint(uint row, uint col)
        {
            Row = row;
            Col = col;
        }

        [MethodImpl(Inline)]
        public GridPoint IncRow()
            => new (Row+1,Col);

        [MethodImpl(Inline)]
        public GridPoint DecRow()
            => new (Row-1,Col);

        [MethodImpl(Inline)]
        public GridPoint IncCol()
            => new (Row,Col+1);

        [MethodImpl(Inline)]
        public GridPoint DecCol()
            => new (Row,Col-1);

        uint IGridPoint.Row
            => Row;

        uint IGridPoint.Col
            => Col;

        [MethodImpl(Inline)]
        public bool Equals(GridPoint src)
            => Row == src.Row && Col == src.Col;

        public override int GetHashCode()
            => (int)alg.hash.combine(Row,Col);

        public string Format()
            => string.Format(RenderPattern, Row, Col);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static GridPoint operator++(GridPoint src)
            => src.IncRow();

        [MethodImpl(Inline)]
        public static GridPoint operator--(GridPoint src)
            => src.DecRow();

        [MethodImpl(Inline)]
        public static implicit operator GridPoint((uint row, uint col) src)
            => new GridPoint(src.row,src.col);

        [MethodImpl(Inline)]
        public static implicit operator (uint row, uint col)(GridPoint src)
            => (src.Row, src.Col);

        [MethodImpl(Inline)]
        public static implicit operator GridPoint<uint>(GridPoint src)
            => new GridPoint<uint>(src.Row, src.Col);

        public static GridPoint Zero
            => new GridPoint(0, 0);

        public static GridPoint Empty
            => new GridPoint(uint.MaxValue,uint.MaxValue);
    }
}