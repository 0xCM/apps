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

            public readonly TextBlock BodyExpr;

            public readonly TextBlock RawBody;

            public readonly InstPatternBody Body;

            public readonly Index<RuleOpSpec> OpSpecs;

            [MethodImpl(Inline)]
            public InstPatternSpec(uint seq, uint instid, IClass @class, string rawbody, InstPatternBody body, RuleOpSpec[] ops)
            {
                PatternId = seq;
                InstId = instid;
                Class = @class;
                Body = body;
                RawBody = rawbody;
                BodyExpr = rawbody;
                OpSpecs = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithOps(RuleOpSpec[] src)
                => new InstPatternSpec(PatternId, InstId, Class, BodyExpr, Body, src);

            [MethodImpl(Inline)]
            public InstPatternSpec WithInstId(uint src)
                => new InstPatternSpec(PatternId, src, Class, BodyExpr, Body, OpSpecs);

            [MethodImpl(Inline)]
            public InstPatternSpec WithPatternId(uint src)
                => new InstPatternSpec(src, InstId, Class, BodyExpr, Body, OpSpecs);

            [MethodImpl(Inline)]
            public InstPatternSpec WithClass(IClass src)
                => new InstPatternSpec(PatternId, InstId, src, BodyExpr, Body, OpSpecs);
            public int CompareTo(InstPatternSpec src)
            {
                var result = InstId.CompareTo(src.InstId);
                if(result == 0)
                    result = BodyExpr.CompareTo(src.BodyExpr);
                return result;
            }

            public string Format()
                => string.Format("Expression:{0}\nOperands:{1}", BodyExpr, OpSpecs);

            public override string ToString()
                => Format();
        }
    }
}