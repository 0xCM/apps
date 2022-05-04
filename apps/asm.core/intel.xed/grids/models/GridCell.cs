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
            public readonly CellKey Key;

            public readonly LogicClass Logic;

            public readonly FieldKind Field;

            public readonly ushort TableIndex;

            public readonly ushort RowIndex;

            public readonly byte ColIndex;

            public readonly ColType Type;

            public readonly DataSize Size;

            public readonly CellValue Value;

            [MethodImpl(Inline)]
            public GridCell(in CellKey key, ColType type, DataSize size, CellValue value)
            {
                Key = key;
                Logic = key.Logic;
                TableIndex = key.Table;
                RowIndex = key.Row;
                Field = key.Field;
                ColIndex = key.Col;
                Type = type;
                Size = size;
                Value = value;
            }

            public GridCol Column
            {
                [MethodImpl(Inline)]
                get => col(this);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Key.IsNonEmpty;
            }

            [MethodImpl(Inline)]
            public int CompareTo(GridCell src)
                => ColIndex.CompareTo(src.ColIndex);

            public string Format()
                => IsEmpty ? EmptyString : string.Format("{0:D3} | {1,-3} | {2,-32} | {3:D2} | {4:D2} | {5} | {6,-6} | {7,-26} | {8}",
                    Key.Table,
                    XedRender.format(Key.Rule.TableKind),
                    XedRender.format(Key.Rule.TableName),
                    RowIndex,
                    ColIndex,
                    Size.Format(2,2,true),
                    XedRender.format(Logic),
                    XedRender.format(Field),
                    Value
                    );

            public override string ToString()
                => Format();

            public static GridCell Empty => default;
        }
    }
}