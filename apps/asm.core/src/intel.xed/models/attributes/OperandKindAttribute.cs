//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-operand-storage.h/all-fields.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedRecords;

    partial struct XedModels
    {
        public class OperandKindAttribute : Attribute
        {
            public OperandKindAttribute(XedOpKind kind, string description = "")
            {
                Kind = kind;
                Description = description;
            }

            public XedOpKind Kind {get;}

            public string Description {get;}
        }
    }
}