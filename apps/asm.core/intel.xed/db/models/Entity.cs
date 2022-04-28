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
        public record class Entity : IEntity<Entity>
        {
            public readonly uint Key;

            public readonly asci32 Name;

            public readonly Index<Relation> Rels;

            public readonly Index<ColSpec> Cols;

            public Entity(uint key, asci32 name, ColSpec[] cols, Relation[] rels)
            {
                Key = key;
                Name = name;
                Cols = cols;
                Rels = rels;
            }

            uint IEntity.Key
                => Key;

            [MethodImpl(Inline)]
            public int CompareTo(Entity src)
                => Key.CompareTo(src.Key);
        }
    }
}