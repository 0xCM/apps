//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct GridField : IComparable<GridField>
        {
            public readonly FieldKind Field;

            public readonly ushort Table;

            public readonly ushort Row;

            public readonly byte Col;

            public readonly byte Width;

            [MethodImpl(Inline)]
            public GridField(ushort table, ushort row, byte col, FieldKind field, byte width)
            {
                Table = table;
                Row = row;
                Field = field;
                Col = col;
                Width = width;
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
            public int CompareTo(GridField src)
                => Col.CompareTo(src.Col);

            public string Format()
                => string.Format("{0:D2} {1:D2} {2:D2} | {3:D2} | {4}", Table, Row, Col, Width, Field);

            public override string ToString()
                => Format();

            public static GridField Empty => default;
        }
    }
}