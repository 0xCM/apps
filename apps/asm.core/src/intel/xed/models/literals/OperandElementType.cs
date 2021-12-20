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
        public readonly struct OperandElementType : ILiteralCover<OperandElementTypeKind>
        {
            public OperandElementTypeKind Value {get;}

            [MethodImpl(Inline)]
            public OperandElementType(OperandElementTypeKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Value.ToString() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OperandElementType(EnumCover<OperandElementTypeKind> src)
                => new OperandElementType(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator OperandElementType(OperandElementTypeKind src)
                => new OperandElementType(src);

            [MethodImpl(Inline)]
            public static implicit operator OperandElementTypeKind(OperandElementType src)
                => src.Value;
        }
    }
}