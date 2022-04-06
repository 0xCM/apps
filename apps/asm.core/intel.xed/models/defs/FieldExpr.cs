//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct FieldExpr
        {
            public readonly FieldValue Value;

            public readonly OperatorKind Operator;

            [MethodImpl(Inline)]
            public FieldExpr(FieldKind field, OperatorKind op, FieldValue value)
            {
                Operator = op;
                Value = value;
            }

            public bool IsEq
            {
                [MethodImpl(Inline)]
                get => Operator == OperatorKind.Eq;
            }

            public bool IsNeq
            {
                [MethodImpl(Inline)]
                get => Operator == OperatorKind.Neq;
            }

            public readonly FieldKind Field
            {
                [MethodImpl(Inline)]
                get => Value.Field;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Value.IsNonEmpty;
            }

            public bool IsNonTerminal
            {
                [MethodImpl(Inline)]
                get => Value.IsNonTerminal;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            public static FieldExpr Empty => new FieldExpr(FieldKind.INVALID,0, FieldValue.Empty);
        }
    }
}