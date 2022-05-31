//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct OperatorType : IDataType<OperatorType>
        {
            public readonly RuleOperator Operator;

            public readonly asci4 Symbol;

            [MethodImpl(Inline)]
            public OperatorType(RuleOperator op)
            {
                Operator = op;
                Symbol = op.Symbol;
            }

            DataSize IDataType.Size
                => default;

            asci64 IDataType.Name
                => Operator.Kind.ToString();
        }
    }
}