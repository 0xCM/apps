//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(80)]
        public readonly struct BitfieldSeg
        {
            public readonly FieldKind Field;

            public readonly text7 Pattern;

            public readonly bool IsLiteral;

            [MethodImpl(Inline)]
            public BitfieldSeg(FieldKind field, text7 pattern, bool literal)
            {
                Field = field;
                Pattern = pattern;
                IsLiteral = literal;
            }

            public FieldAssignment ToAssignment()
            {
                var dst = FieldAssignment.Empty;
                if(IsLiteral)
                {
                    BitNumbers.parse(Pattern.Format(), out uint5 value).Require();
                    dst = new FieldAssignment(Field, value);
                }
                return dst;
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
                => format(this);

            public override string ToString()
                => Format();

            public static BitfieldSeg Empty => default;
        }
    }
}