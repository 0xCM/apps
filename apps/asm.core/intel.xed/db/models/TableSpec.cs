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
        public record class TableSpec : IEntity<TableSpec>
        {
            public readonly ushort Id;

            public readonly asci32 Name;

            public readonly Index<Relation> Rels;

            public readonly Index<ColSpec> Cols;

            public TableSpec(ushort id, asci32 name, ColSpec[] cols, Relation[] rels)
            {
                Id = id;
                Name = name;
                Cols = cols;
                Rels = rels;
            }

            ref readonly Index<Relation> IEntity<TableSpec>.Rels
                => ref Rels;

            [MethodImpl(Inline)]
            public int CompareTo(TableSpec src)
                => Id.CompareTo(src.Id);
        }
    }
}