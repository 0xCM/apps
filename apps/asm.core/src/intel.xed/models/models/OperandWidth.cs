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
        [DataType(Names.opwidth)]
        public struct OperandWidth : IEnumCover<OperandWidthType>
        {
            public OperandWidthType Value {get;set;}

            [MethodImpl(Inline)]
            public OperandWidth(OperandWidthType kind)
            {
                Value = kind;
            }

            [MethodImpl(Inline)]
            public static implicit operator OperandWidth(OperandWidthType type)
                => new OperandWidth(type);
        }
    }
}