//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    public readonly struct XedLogic
    {
        [MethodImpl(Inline)]
        public static FieldOp<T> operand<T>(FieldKind field, RuleOperator op, T value)
            where T : unmanaged, ILogicValue<T>
                => new FieldOp<T>(field, op, value);

        [MethodImpl(Inline)]
        public static RuleOp<T> operand<T>(Nonterminal rule, RuleOperator op, T value)
            where T : unmanaged, ILogicValue<T>
                => new RuleOp<T>(rule, op, value);
    }
}