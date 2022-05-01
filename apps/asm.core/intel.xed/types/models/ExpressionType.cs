//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), DataWidth(MetaWidth,MetaWidth)]
        public readonly struct ExpressionType :  IFieldType<ExpressionType>
        {
            internal const uint MetaWidth = FieldType.MetaWidth + OperatorType.MetaWidth;

            public readonly FieldType Field;

            public readonly OperatorType Operator;

            [MethodImpl(Inline)]
            public ExpressionType(FieldType field, OperatorType op)
            {
                Field = field;
                Operator = op;
            }

            public RuleTypeKind TypeKind
            {
                [MethodImpl(Inline)]
                get => RuleTypeKind.Expression;
            }

            public CellType DataType
            {
                [MethodImpl(Inline)]
                get => Field.DataType;
            }

            FieldKind IFieldType.Field
                => Field.Field;

            asci32 IRuleType.TypeName
                => Field.DataType.TypeName;
        }
    }
}