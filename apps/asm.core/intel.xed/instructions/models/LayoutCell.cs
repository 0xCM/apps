//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules.LayoutCellKind;

    partial class XedRules
    {
        public readonly record struct LayoutCell
        {
            readonly ByteBlock16 Data;

            [MethodImpl(Inline)]
            internal LayoutCell(ByteBlock16 data)
            {
                Data = data;
            }

            [MethodImpl(Inline)]
            public ref readonly Hex8 AsHexLit()
                => ref @as<Hex8>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly uint5 AsBitLit()
                => ref @as<uint5>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly FieldSeg AsSegField()
                => ref @as<FieldSeg>(Data.First);

            [MethodImpl(Inline)]
            public ref readonly Nonterminal AsNonterm()
                => ref @as<Nonterminal>(Data.First);

            public ref readonly LayoutCellKind Kind
            {
                [MethodImpl(Inline)]
                get => ref @as<LayoutCellKind>(Data[15]);
            }

            public bool IsRule
            {
                [MethodImpl(Inline)]
                get => Kind == LayoutCellKind.NT;
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

            public string Format()
            {
                var dst = EmptyString;
                switch(Kind)
                {
                    case None:
                        dst = EmptyString;
                    break;
                    case BL:
                        dst = XedRender.format(AsBitLit());
                    break;
                    case XL:
                        dst = XedRender.format(AsHexLit());
                    break;
                    case SF:
                        dst = XedRender.format(AsSegField());
                    break;
                    case NT:
                        dst = XedRender.format(AsNonterm());
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static LayoutCell Empty => default;
        }
    }
}