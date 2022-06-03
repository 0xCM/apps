//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct EntityRef : IComparable<EntityRef>
        {
            public readonly uint Kind;

            public readonly uint Key;

            [MethodImpl(Inline)]
            public EntityRef(uint kind, uint key)
            {
                Key  = key;
                Kind = kind;
            }

            [MethodImpl(Inline)]
            public int CompareTo(EntityRef src)
                => Key.CompareTo(src.Key);
        }
    }
}