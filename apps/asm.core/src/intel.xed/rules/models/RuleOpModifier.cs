//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleOpModifier
        {
            public readonly RuleOpModKind Kind;

            [MethodImpl(Inline)]
            public RuleOpModifier(RuleOpModKind kind)
            {
                Kind = kind;
            }

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

        }
    }
}