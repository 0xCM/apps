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
            public const ObjectKind ObjKind = ObjectKind.TypeTable;

            public readonly uint TypeKey;

            public readonly Label TypeName;

            public readonly byte PackedWidth;

            public readonly uint NativeWidth;

            public readonly ushort RowCount;

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
        }
    }
}