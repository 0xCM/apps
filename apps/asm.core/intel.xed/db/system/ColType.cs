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
            public readonly ushort Id;

            public readonly ColKind Kind;

            public readonly asci16 TypeName;

            [MethodImpl(Inline)]
            public ColType(ColKind kind, asci16 name)
            {
                Id = (byte)((ushort)kind | (ushort)kind << 5);
                Kind = kind;
                TypeName = name;
            }

            [MethodImpl(Inline)]
            public ColType(ushort id, asci16 name)
            {
                Id = id;
                Kind = (ColKind)(id & uint5.MaxValue);
                TypeName = name;
            }

            [MethodImpl(Inline)]
            public ColType(ushort id, ColKind kind, asci16 name)
            {
                Id = id;
                Kind = kind;
                TypeName = name;
            }

            public int CompareTo(ColType src)
                => Id.CompareTo(src);

            public string Format()
                => string.Format("{0,-6} | {1,-8} | {2}");

            public override string ToString()
                => Format();
        }
    }
}