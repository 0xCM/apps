//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct RegSpec
        {
            public readonly RegSpecKind Kind;

            readonly ushort Data;

            [MethodImpl(Inline)]
            public RegSpec(GroupName src)
            {
                Kind = RegSpecKind.EncGroup;
                Data = (ushort)src;
            }

            [MethodImpl(Inline)]
            public RegSpec(XedRegId src)
            {
                Kind = RegSpecKind.Literal;
                Data = (ushort)src;
            }

            public bool IsLiteral
            {
                [MethodImpl(Inline)]
                get => Kind == RegSpecKind.Literal;
            }

            public bool IsEncGroup
            {
                [MethodImpl(Inline)]
                get => Kind == RegSpecKind.EncGroup;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            [MethodImpl(Inline)]
            public GroupName AsEncGroup()
                => (GroupName)Data;

            [MethodImpl(Inline)]
            public XedRegId AsLiteral()
                => (XedRegId)Data;

            public string Format()
                => IsEncGroup ? XedRender.format(AsEncGroup())
                : IsLiteral ? XedRender.format(AsLiteral())
                : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator RegSpec(GroupName src)
                => new RegSpec(src);

            [MethodImpl(Inline)]
            public static implicit operator RegSpec(XedRegId src)
                => new RegSpec(src);
        }

        public enum RegSpecKind : byte
        {
            None,

            Literal,

            EncGroup,
        }
    }
}