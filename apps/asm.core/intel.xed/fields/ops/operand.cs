//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedFields
    {
        [MethodImpl(Inline)]
        public static FieldOperand<T> operand<T>(FieldKind field, RuleOperator op, T value)
            where T : unmanaged, ILogicValue<T>
                => new FieldOperand<T>(field, op, value);

        [MethodImpl(Inline)]
        public static RuleOperand<T> operand<T>(Nonterminal rule, RuleOperator op, T value)
            where T : unmanaged, ILogicValue<T>
                => new RuleOperand<T>(rule, op, value);
    }
}