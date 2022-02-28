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
        public class RuleOperandAttribute : Attribute
        {
            public RuleOperandAttribute(FieldKind kind, byte width)
            {
                Kind = kind;
                Width = width;
            }

            public RuleOperandAttribute(FieldKind kind)
            {
                Kind = kind;
                Width = 0;
            }

            public FieldKind Kind {get;}

            public byte Width {get;}
        }
    }
}