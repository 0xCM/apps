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
        public class RuleFieldAttribute : Attribute
        {
            public RuleFieldAttribute(FieldKind kind, byte width = 0)
            {
                Kind = kind;
                Width = width;
            }

            public FieldKind Kind {get;}

            public byte Width {get;}
        }
    }
}