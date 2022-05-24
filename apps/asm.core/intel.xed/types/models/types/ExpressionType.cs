//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedTypes
    {
        [StructLayout(StructLayout,Pack=1)]
        public readonly record struct ExpressionType :  IFieldType<ExpressionType>
        {
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

            DataSize IDataType.Size
                => Size;

            FieldKind IFieldType.Field
                => Field.Field;

            asci64 IDataType.Name
                => Field.DataType.TypeName;
        }
    }
}