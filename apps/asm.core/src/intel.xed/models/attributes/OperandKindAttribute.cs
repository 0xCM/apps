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
            public OperandKindAttribute(OpKind kind, string description = "")
            {
                Kind = kind;
                Description = description;
            }

            public OpKind Kind {get;}

            public string Description {get;}
        }
    }
}