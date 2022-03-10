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

            public FieldAssign ToAssignment()
            {
                var dst = FieldAssign.Empty;
                if(IsLiteral)
                {
                    BitNumbers.parse(Pattern.Format(), out uint8b u8).Require();
                    dst = new FieldAssign(value(Field, (byte)u8));
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
                => RuleTables.format(this);

            public override string ToString()
                => Format();

            public static BitfieldSeg Empty => default;
        }
    }
}