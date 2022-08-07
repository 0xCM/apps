//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public record class Entity : IEntity<Entity,uint>
        {
            public readonly uint Key;

            public readonly asci32 Name;

            public readonly Index<Relation16> Rels;

            public readonly Index<ColSpec> Cols;

            [MethodImpl(Inline)]
            public Entity(uint key, asci32 name, ColSpec[] cols, Relation16[] rels)
            {
                Key = key;
                Name = name;
                Cols = cols;
                Rels = rels;
            }

            uint IKeyed<uint>.Key   
                => Key;

            [MethodImpl(Inline)]
            public int CompareTo(Entity src)
                => Key.CompareTo(src.Key);
        }
    }
}