//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Identifies a cell within the context of a table
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct CellIndex : IDataTypeComparable<CellIndex>
    {
        /// <summary>
        /// A zero-based row index
        /// </summary>
        public uint Row {get;}

        /// <summary>
        /// A zero-based column index
        /// </summary>
        public uint Col {get;}

        [MethodImpl(Inline)]
        public CellIndex(uint row, uint col)
        {
            Row = row;
            Col = col;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => FastHash.combine(Row,Col);
        }

        public string Format()
            => string.Format("({0},{1})", Row, Col);

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        public bool Equals(CellIndex src)
            => Row == src.Row && Col == src.Col;

        public override bool Equals(object src)
            => src is CellIndex x && Equals(src);

        [MethodImpl(Inline)]
        public int CompareTo(CellIndex src)
        {
            if(Row == src.Row)
                return Col.CompareTo(src.Col);
            else
                return Row.CompareTo(src.Row);
        }

        [MethodImpl(Inline)]
        public static bool operator ==(CellIndex a, CellIndex b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(CellIndex a, CellIndex b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator CellIndex((uint row, uint col) src)
            => new CellIndex(src.row, src.col);

        public static CellIndex Zero => default;

        public static CellIndex Empty
            => new CellIndex(uint.MaxValue, uint.MaxValue);
    }
}