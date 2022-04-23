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
        public readonly struct CellExpr
        {
            public readonly CellValue Value;

            public readonly RuleOperator Operator;

            [MethodImpl(Inline)]
            public CellExpr(OperatorKind op, CellValue value)
            {
                Operator = op;
                Value = value;
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

            public bool IsNonterm
            {
                [MethodImpl(Inline)]
                get => Value.IsNonterm;
            }

            public string Format()
                => CellRender.format(this);

            public override string ToString()
                => Format();

            public static CellExpr Empty => new CellExpr(0, CellValue.Empty);
        }
    }
}