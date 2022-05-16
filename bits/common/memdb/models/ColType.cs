//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        public readonly record struct ColType : IElement<ColType>
        {
            public readonly uint Key;

            public readonly asci64 TypeName;

            [MethodImpl(Inline)]
            public ColType(uint key, asci64 name)
            {
                Key = key;
                TypeName = name;
            }

            public int CompareTo(ColType src)
                => TypeName.CompareTo(src.TypeName);

            public string Format()
                => string.Format("{0,-6} | {1,-8} | {2}");

            public override string ToString()
                => Format();
        }
    }
}