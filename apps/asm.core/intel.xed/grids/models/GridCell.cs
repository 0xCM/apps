//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedGrids
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct GridCell : IComparable<GridCell>
        {
            public readonly FieldKind Field;

            public readonly ushort Table;

            public readonly ushort Row;

            public readonly byte Col;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public GridCell(ushort table, ushort row, byte col, FieldKind field, DataSize size)
            {
                Table = table;
                Row = row;
                Field = field;
                Col = col;
                Size = size;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            [MethodImpl(Inline)]
            public int CompareTo(GridCell src)
                => Col.CompareTo(src.Col);

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0:D2} {1:D2} {2:D2} | {3,-8} | {4}", Table, Row, Col, Size.Format(true), Field);

            public override string ToString()
                => Format();

            public static GridCell Empty => default;
        }
    }
}