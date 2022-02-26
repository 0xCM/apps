//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;

    partial struct XedModels
    {
        public class OperandKindAttribute : Attribute
        {
            public OperandKindAttribute(FieldKind kind, string description = "")
            {
                Kind = kind;
                Description = description;
            }

            public FieldKind Kind {get;}

            public string Description {get;}
        }
    }
}