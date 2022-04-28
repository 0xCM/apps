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
        public readonly record struct TableDef : IEntity<TableDef>
        {
            public readonly uint Key;

            public readonly asci32 Name;

            public readonly Index<ColDef> Cols;

            [MethodImpl(Inline)]
            public TableDef(uint seq, asci32 name, ColDef[] cols)
            {
                Key = seq;
                Name = name;
                Cols = cols;
            }

            [MethodImpl(Inline)]
            public int CompareTo(TableDef src)
                => Name.CompareTo(src.Name);

            uint IEntity.Key
                => Key;
        }
    }
}