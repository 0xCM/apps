//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public struct MacroExpansion
        {
            public readonly FieldKind Field;

            public readonly OperatorKind Operator;

            public readonly CellValue Value;

            [MethodImpl(Inline)]
            public MacroExpansion(FieldKind field, OperatorKind op, CellValue value)
            {
                Field = field;
                Operator = op;
                Value = value;
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

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();
        }
    }
}