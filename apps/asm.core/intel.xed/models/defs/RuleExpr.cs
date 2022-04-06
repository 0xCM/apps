//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        public readonly struct RuleExpr : IEquatable<RuleExpr>
        {
            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly RuleCellType CellType;

            public readonly FieldValue Value;

            public readonly asci64 Source;

            [MethodImpl(Inline)]
            public RuleExpr(FieldKind field, RuleOperator op, RuleCellType type, FieldValue value, string src)
            {
                CellType = type;
                Field = field;
                Operator = op;
                Value = value;
                Source = src;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0 && Operator.IsEmpty && (Value.IsEmpty || Value.IsEmpty);
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Field != 0 || Operator.IsNonEmpty || (Value.IsNonEmpty && !Value.IsEmpty);
            }

            [MethodImpl(Inline)]
            public bool Equals(RuleExpr src)
                => Field == src.Field && Operator == src.Operator && Value == src.Value;

            public override int GetHashCode()
                => (int)alg.hash.marvin(Format());

            public override bool Equals(object src)
                => src is RuleExpr x && Equals(x);

            public string Format()
            {
                var dst = string.Format("{0}{1}{2}", XedRender.format(Field), Operator.Format(), Value);
                switch(CellType.Kind)
                {
                    case CK.BfSeg:
                    case CK.DispSeg:
                    case CK.ImmSeg:
                        dst = string.Format("{0}[{1}]", XedRender.format(Field), Value);
                    break;
                    case CK.NontermCall:
                        dst = Value.Format();
                    break;
                }
                return dst;
            }

            public override string ToString()
                => Format();

            public static RuleExpr Empty => default;
        }
    }
}