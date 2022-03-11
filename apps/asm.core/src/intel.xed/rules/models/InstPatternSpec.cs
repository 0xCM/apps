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
        public readonly struct InstPatternSpec : IComparable<InstPatternSpec>
        {
            public readonly uint PatternId;

            public readonly uint InstId;

            public readonly IClass Mnemonic;

            public readonly TextBlock Expression;

            public readonly Index<RuleOpSpec> Operands;

            [MethodImpl(Inline)]
            public InstPatternSpec(uint seq, uint instid, IClass @class, string expr, RuleOpSpec[] ops)
            {
                PatternId = seq;
                InstId = instid;
                Mnemonic = @class;
                Expression = expr;
                Operands = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithInst(uint instid)
                => new InstPatternSpec(PatternId, instid, Mnemonic, Expression, Operands);

            [MethodImpl(Inline)]
            public InstPatternSpec WithPattern(string pattern)
                => new InstPatternSpec(PatternId, InstId, Mnemonic, pattern, Operands);

            public int CompareTo(InstPatternSpec src)
            {
                var result = InstId.CompareTo(src.InstId);
                if(result == 0)
                    result = Expression.CompareTo(src.Expression);
                return result;
            }
            public string Format()
                => string.Format("Expression:{0}\nOperands:{1}", Expression, Operands);

            public override string ToString()
                => Format();
        }
    }
}