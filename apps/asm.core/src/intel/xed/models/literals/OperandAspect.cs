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
        public struct OperandAspect : IEnumCover<OperandAspectKind>
        {
            public OperandAspectKind Value {get;set;}

            [MethodImpl(Inline)]
            public OperandAspect(OperandAspectKind src)
            {
                Value = src;
            }

            public string Format()
                => Value != 0 ? Symbols.expr(Value).Format() : EmptyString;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator OperandAspect(EnumCover<OperandAspectKind> src)
                => new OperandAspect(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator OperandAspect(OperandAspectKind src)
                => new OperandAspect(src);

            [MethodImpl(Inline)]
            public static implicit operator OperandAspectKind(OperandAspect src)
                => src.Value;
        }
    }
}