//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-OperandElementType-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        [DataType(Names.optype)]
        public struct OperandType : IEnumCover<OperandTypeKind>
        {
            public OperandTypeKind Value {get;set;}

            [MethodImpl(Inline)]
            public OperandType(OperandTypeKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Symbols.expr(Value).Format() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OperandType(EnumCover<OperandTypeKind> src)
                => new OperandType(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator OperandType(OperandTypeKind src)
                => new OperandType(src);

            [MethodImpl(Inline)]
            public static implicit operator OperandTypeKind(OperandType src)
                => src.Value;
        }
    }
}