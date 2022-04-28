//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
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