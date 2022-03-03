//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleToken
        {
            public readonly RuleTokenKind Kind;

            public readonly text31 Value;

            [MethodImpl(Inline)]
            public RuleToken(RuleTokenKind kind, text31 value)
            {
                Kind = kind;
                Value = value;
            }

            public static RuleToken Empty => default;
        }
    }
}