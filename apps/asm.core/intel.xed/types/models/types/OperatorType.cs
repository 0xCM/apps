//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct OperatorType : IDataType<OperatorType>
        {
            public const TypeKind Kind = TypeKind.Operator;

            public readonly RuleOperator Operator;

            public readonly asci4 Symbol;

            [MethodImpl(Inline)]
            public OperatorType(RuleOperator op)
            {
                Operator = op;
                Symbol = op.Symbol;
            }

            TypeKind IDataType.Kind
                => Kind;

            asci32 IDataType.Name
                => Operator.Kind.ToString();
        }
    }
}