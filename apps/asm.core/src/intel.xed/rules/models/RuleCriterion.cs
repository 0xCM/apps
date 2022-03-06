//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleCriterion
        {
            public readonly bool IsPremise;

            public readonly FieldKind Field;

            public readonly RuleOperator Operator;

            public readonly FieldDataType DataType;

            public readonly ulong Data;

            [MethodImpl(Inline)]
            internal RuleCriterion(bool premise, FieldKind field, RuleOperator op, FieldDataType type, ulong data)
            {
                IsPremise = premise;
                Field = field;
                Operator = op;
                DataType = type;
                Data = data;
            }

            public bool IsConsequent
            {
                [MethodImpl(Inline)]
                get => !IsPremise;
            }

            [MethodImpl(Inline)]
            public ImmFieldSpec AsImmField()
                => core.@as<ulong,ImmFieldSpec>(Data);

            [MethodImpl(Inline)]
            public DispFieldSpec AsDispField()
                => core.@as<ulong,DispFieldSpec>(Data);

            public string Format()
                => RuleTables.format(this);

            public override string ToString()
                => Format();

            public static RuleCriterion Empty => default;
        }
    }
}