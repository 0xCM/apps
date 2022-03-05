//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public readonly struct InstPatternSpec
        {
            public readonly TextBlock Expression;

            public readonly Index<RuleOpSpec> Operands;

            [MethodImpl(Inline)]
            public InstPatternSpec(string expr, RuleOpSpec[] ops)
            {
                Expression = expr;
                Operands = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithPattern(string pattern)
                => new InstPatternSpec(pattern, Operands);

            public string Format()
                => string.Format("Expression:{0}\nOperands:{1}", Expression, Operands);

            public override string ToString()
                => Format();
        }
    }
}