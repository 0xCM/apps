//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial struct XedModels
    {
        public class OperandKindAttribute : Attribute
        {
            public OperandKindAttribute(OperandKind kind)
            {
                Kind = kind;
            }

            public OperandKind Kind {get;}
        }
    }
}