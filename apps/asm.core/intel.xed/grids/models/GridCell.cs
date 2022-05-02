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
            public readonly LogicClass Logic;

            public readonly FieldKind Field;

            public readonly ushort TableIndex;

            public readonly ushort RowIndex;

            public readonly byte ColIndex;

            public readonly ColType Type;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public GridCell(LogicClass logic, ushort table, ushort row, byte col, FieldKind field, ColType type, DataSize size)
            {
                Logic = logic;
                TableIndex = table;
                RowIndex = row;
                Field = field;
                ColIndex = col;
                Type = type;
                Size = size;
            }

            public GridCol Column
            {
                [MethodImpl(Inline)]
                get => col(this);
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
                => ColIndex.CompareTo(src.ColIndex);

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0,-6} | {0:D2} {1:D2} {2:D2} | {3,-8} | {4}", Logic, TableIndex, RowIndex, ColIndex, Size.Format(true), Field);

            public override string ToString()
                => Format();

            public static GridCell Empty => default;
        }
    }
}