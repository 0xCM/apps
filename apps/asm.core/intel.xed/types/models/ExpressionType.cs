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
            public const uint MetaWidth = FieldType.MetaWidth + OperatorType.MetaWidth;

            public const TypeKind Kind = TypeKind.Expression;

            public readonly FieldType Field;

            public readonly OperatorType Operator;

            [MethodImpl(Inline)]
            public ExpressionType(FieldType field, OperatorType op)
            {
                Field = field;
                Operator = op;
            }

            TypeKind IRuleType.TypeKind
                => Kind;

            FieldKind IFieldType.Field
                => Field.Field;

            asci32 IRuleType.TypeName
                => Field.DataType.TypeName;
        }
    }
}