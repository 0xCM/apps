//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct BfSeg
        {
            public readonly FieldKind Field;

            public readonly asci8 Pattern;

            public readonly bool IsLiteral;

            [MethodImpl(Inline)]
            public BfSeg(FieldKind field, asci8 pattern, bool literal)
            {
                Field = field;
                Pattern = pattern;
                IsLiteral = literal;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static BfSeg Empty => default;
        }
    }
}