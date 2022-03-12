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

            public readonly IClass Class;

            public readonly TextBlock Expression;

            public readonly Index<InstDefSeg> Body;

            public readonly Index<RuleOpSpec> Operands;

            [MethodImpl(Inline)]
            public InstPatternSpec(uint seq, uint instid, IClass @class, string expr, InstDefSeg[] body,  RuleOpSpec[] ops)
            {
                PatternId = seq;
                InstId = instid;
                Class = @class;
                Expression = expr;
                Operands = ops;
                Body = sys.empty<InstDefSeg>();
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithInstId(uint instid)
                => new InstPatternSpec(PatternId, instid, Class, Expression, Body, Operands);

            [MethodImpl(Inline)]
            public InstPatternSpec WithExpr(string expr)
                => new InstPatternSpec(PatternId, InstId, Class, expr, Body, Operands);

            [MethodImpl(Inline)]
            public InstPatternSpec WithBody(params InstDefSeg[] body)
                => new InstPatternSpec(PatternId, InstId, Class, Expression, body, Operands);

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