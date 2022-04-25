//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    [ApiHost]
    public partial class XedGrids : AppService<XedGrids>
    {
        [MethodImpl(Inline)]
        public static FieldOperand<T> operand<T>(FieldKind field, RuleOperator op, T value)
            where T : unmanaged, ILogicValue<T>
                => new FieldOperand<T>(field, op, value);

        [MethodImpl(Inline)]
        public static RuleOperand<T> operand<T>(Nonterminal rule, RuleOperator op, T value)
            where T : unmanaged, ILogicValue<T>
                => new RuleOperand<T>(rule, op, value);

        [MethodImpl(Inline)]
        public static LogicValue<T> value<T>(LogicDataKind kind, byte width, T data)
            where T : unmanaged
                => new LogicValue<T>(kind,width,data);

        [MethodImpl(Inline)]
        public static LogicCell<T> cell<T>(CellKey key, T value)
            where T : unmanaged,  ILogicValue<T>, IEquatable<T>, ILogicOperand<T>
                => new LogicCell<T>(key,value);
    }
}
