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
            public readonly TextBlock PatternExpr;

            public readonly Index<RuleOpSpec> PatternOps;

            [MethodImpl(Inline)]
            public InstPatternSpec(string expr, RuleOpSpec[] ops)
            {
                PatternExpr = expr;
                PatternOps = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithPattern(string pattern)
                => new InstPatternSpec(pattern, PatternOps);

            public string Format()
                => string.Format("Pattern:{0}\nOperands:{1}", PatternExpr, PatternOps);

            public override string ToString()
                => Format();
        }
    }
}