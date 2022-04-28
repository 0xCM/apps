//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        public readonly record struct EntityRef<T>: IComparable<EntityRef<T>>
        {
            public readonly uint Key;

            [MethodImpl(Inline)]
            public EntityRef(uint key)
            {
                Key  = key;
            }

            [MethodImpl(Inline)]
            public int CompareTo(EntityRef<T> src)
                => Key.CompareTo(src.Key);

            [MethodImpl(Inline)]
            public uint Kind()
                => alg.hash.marvin(typeof(T).AssemblyQualifiedName);

            [MethodImpl(Inline)]
            public static implicit operator EntityRef<T>(uint key)
                => new EntityRef<T>(key);

            [MethodImpl(Inline)]
            public static implicit operator uint(EntityRef<T> src)
                => src.Key;

            [MethodImpl(Inline)]
            public static implicit operator EntityRef(EntityRef<T> src)
                => new EntityRef(src.Kind(), src.Key);
        }
    }
}