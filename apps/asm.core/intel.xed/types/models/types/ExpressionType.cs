//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDataTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly struct ExpressionType :  IFieldType<ExpressionType>
        {
            public const TypeKind Kind = TypeKind.Expression;

            public readonly FieldType Field;

            public readonly OperatorType Operator;

            public readonly DataSize Size;

            [MethodImpl(Inline)]
            public ExpressionType(FieldType field, OperatorType op, DataSize size)
            {
                Field = field;
                Operator = op;
                Size = size;
            }

            TypeKind IDataType.Kind
                => Kind;

            FieldKind IFieldType.Field
                => Field.Field;

            asci32 IDataType.Name
                => Field.DataType.TypeName;
        }
    }
}