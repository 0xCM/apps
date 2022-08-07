//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record class ColSpec : IEntity<ColSpec,uint>
        {
            public readonly uint Key;

            public readonly DbDataType Type;

            public readonly asci32 Name;

            [MethodImpl(Inline)]
            public ColSpec(uint key, DbDataType type, asci32 name)
            {
                Key = key;
                Type = type;
                Name = name;
            }

            uint IKeyed<uint>.Key
                => Key;

            [MethodImpl(Inline)]
            public int CompareTo(ColSpec src)
                => Key.CompareTo(src.Key);
        }
    }
}