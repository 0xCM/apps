//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleCellExpr : IEquatable<RuleCellExpr>
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly asci64 Value;

            [MethodImpl(Inline)]
            public RuleCellExpr(FieldKind field, RuleOperator op, asci64 value)
            {
                Field = field;
                Operator = op;
                Value = value;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0 && Operator.IsEmpty && (Value.IsEmpty || Value.IsBlank);
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0 || Operator.IsNonEmpty || (Value.IsNonEmpty && !Value.IsBlank);
            }

            [MethodImpl(Inline)]
            public bool Equals(RuleCellExpr src)
                => Field == src.Field && Operator == src.Operator && Value == src.Value;

            public override int GetHashCode()
                => (int)alg.hash.marvin(Format());

            public override bool Equals(object src)
                => src is RuleCellExpr x && Equals(x);

            public string Format()
            {
                var dst = EmptyString;
                if(Field != 0)
                    dst = XedRender.format(Field);

                if(Operator.IsNonEmpty)
                    dst += Operator.Format();

                var value = Value.Format();
                if(text.nonempty(value))
                {
                    if(Operator.IsNonEmpty)
                        dst += value;
                    else
                    {
                        if(Field != 0)
                            dst += " ";
                        dst += value;
                    }
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static RuleCellExpr Empty => default;
        }
    }
}