//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct TypeTable : IEntity<TypeTable,uint>
        {
            public readonly uint Key;

            public readonly Label TypeName;

            public readonly byte PackedWidth;

            public readonly uint NativeWidth;

            public readonly ushort RowCount;

            public readonly Index<TypeTableRow> Rows;

            [MethodImpl(Inline)]
            public TypeTable(uint key, Label name, DataSize size, TypeTableRow[] rows)
            {
                Key = key;
                TypeName = name;
                NativeWidth = size.NativeWidth;
                PackedWidth = (byte)size.PackedWidth;
                RowCount = (ushort)rows.Length;
                Rows = rows;
            }

            uint IKeyed<uint>.Key 
                => Key;

            [MethodImpl(Inline)]
            public int CompareTo(TypeTable src)
                => TypeName.CompareTo(src.TypeName);

        }
    }
}