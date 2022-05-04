//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct OperatorType : IRuleType<OperatorType>
        {
            public const uint MetaWidth = RuleOperator.AlignedWidth + asci4.Size*8;

            public const TypeKind Kind = TypeKind.Operator;

            public readonly RuleOperator Operator;

            public readonly asci4 Symbol;

            [MethodImpl(Inline)]
            public OperatorType(RuleOperator op)
            {
                Operator = op;
                Symbol = op.Symbol;
            }

            TypeKind IRuleType.TypeKind
                => Kind;

            asci32 IRuleType.TypeName
                => Operator.Kind.ToString();
        }
    }
}