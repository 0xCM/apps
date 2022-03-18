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

            public readonly RuleOperator Operator;

            public readonly FieldValue Value;

            [MethodImpl(Inline)]
            public MacroExpansion(FieldKind field, RuleOperator op, FieldValue value)
            {
                Field = field;
                Operator = op;
                Value = value;
            }

            public string Format()
                => string.Format("{0}{1}{2}", XedRender.format(Field), XedRender.format(Operator), XedRender.format(Value));

            public override string ToString()
                => Format();
        }
    }
}