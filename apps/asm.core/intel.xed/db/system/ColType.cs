//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
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