//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct ColType : IEntity<ColType>
        {
            public readonly uint Key;

            public readonly Name TypeName;

            [MethodImpl(Inline)]
            public ColType(uint key, Name name)
            {
                Key = key;
                TypeName = name;
            }

            uint IEntity.Key
                => Key;

            public int CompareTo(ColType src)
                => TypeName.CompareTo(src.TypeName);

            public string Format()
                => string.Format("{0,-6} | {1,-8} | {2}");

            public override string ToString()
                => Format();
        }
    }
}