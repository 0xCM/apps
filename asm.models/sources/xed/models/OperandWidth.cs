//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct OperandWidth
        {
            public OperandWidthType Kind {get;}

            [MethodImpl(Inline)]
            public OperandWidth(OperandWidthType kind)
            {
                Kind = kind;
            }

            [MethodImpl(Inline)]
            public static implicit operator OperandWidth(OperandWidthType type)
                => new OperandWidth(type);
        }
    }
}