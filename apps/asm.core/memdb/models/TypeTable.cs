//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct TypeTable : ITable<TypeTable>
        {
            public const byte ColCount = 5;

            public const ObjectKind ObjKind = ObjectKind.TypeTable;

            [Render(8)]
            public readonly uint TypeKey;

            [Render(32)]
            public readonly Label TypeName;

            [Render(12)]
            public readonly byte PackedWidth;

            [Render(12)]
            public readonly uint NativeWidth;

            [Render(12)]
            public readonly ushort RowCount;

            [Ignore]
            public readonly Index<TypeTableRow> Rows;

            [MethodImpl(Inline)]
            public TypeTable(uint key, Label name, DataSize size, TypeTableRow[] rows)
            {
                TypeKey = key;
                TypeName = name;
                NativeWidth = size.NativeWidth;
                PackedWidth = (byte)size.PackedWidth;
                RowCount = (ushort)rows.Length;
                Rows = rows;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TypeTable src)
                => TypeName.CompareTo(src.TypeName);

            uint IEntity.Key
                => TypeKey;

            public static Index<ColDef> Columns(ref ushort pos)
                =>  cols(new ColDef[ColCount]{
                    col(pos++, nameof(TypeKey), RenderWidths),
                    col(pos++, nameof(TypeName), RenderWidths),
                    col(pos++, nameof(PackedWidth), RenderWidths),
                    col(pos++, nameof(NativeWidth), RenderWidths),
                    col(pos++, nameof(RowCount), RenderWidths),
                        });

            static ReadOnlySpan<byte> RenderWidths => new byte[ColCount]{8,32,12,12,12};
        }
    }
}