//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XedRules
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