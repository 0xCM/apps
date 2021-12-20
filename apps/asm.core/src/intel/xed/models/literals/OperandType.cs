//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-OperandType-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct OperandType : ILiteralCover<OperandTypeKind>
        {
            public OperandTypeKind Value {get;}

            [MethodImpl(Inline)]
            public OperandType(OperandTypeKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Value.ToString() : EmptyString;

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