//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct TypeTable : ITable<TypeTable>
        {
            public static TableDef Def => table(nameof(TypeTable),
                    col(0, ColKind.Asci32, nameof(TypeName)),
                    col(1, ColKind.U8, nameof(RowDataWidth)),
                    col(2, ColKind.U16, nameof(RowCount)),
                    col(3, ColKind.TableSeq, nameof(Rows))
                );

            public readonly asci32 TypeName;

            public readonly byte RowDataWidth;

            public readonly ushort RowCount;

            public readonly Index<TypeTableRow> Rows;

            [MethodImpl(Inline)]
            public TypeTable(asci32 name, byte width, TypeTableRow[] rows)
            {
                TypeName = name;
                RowDataWidth = width;
                RowCount = (ushort)rows.Length;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TypeTable src)
                => TypeName.CompareTo(src.TypeName);
        }
    }
}