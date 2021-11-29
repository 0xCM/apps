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
    /// Locates a cell within a grid
    /// </summary>
     public struct GridPoint : IGridPoint<GridPoint>
     {
        internal const string RenderPattern = "({0},{1})";

        /// <summary>
        /// The cell row
        /// </summary>
        public uint Row {get; private set;}

        /// <summary>
        /// The cell column
        /// </summary>
        public uint Col {get; private set;}

        [MethodImpl(Inline)]
        public GridPoint(uint row, uint col)
        {
            Row = row;
            Col = col;
        }

        [MethodImpl(Inline)]
        public GridPoint IncRow()
        {
            Row = add(Row,1);
            return this;
        }

        [MethodImpl(Inline)]
        public GridPoint DecRow()
        {
            Row = sub(Row,1);
            return this;
        }

        [MethodImpl(Inline)]
        public GridPoint IncCol()
        {
            Col = add(Col,1);
            return this;
        }

        [MethodImpl(Inline)]
        public GridPoint DecCol()
        {
            Col = sub(Col,1);
            return this;
        }

        [MethodImpl(Inline)]
        public bool Equals(GridPoint src)
            => Row == src.Row && Col == src.Col;

        public override int GetHashCode()
            => (int)alg.hash.combine(Row,Col);

        public override bool Equals(object src)
            => src is GridPoint x && Equals(x);

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