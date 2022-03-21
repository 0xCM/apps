//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public readonly struct InstPatternSpec : IComparable<InstPatternSpec>
        {
            public readonly uint PatternId;

            public readonly uint InstId;

            public readonly IClass Class;

            public readonly TextBlock BodyExpr;

            public readonly TextBlock RawBody;

            public readonly InstPatternBody Body;

            public readonly Index<OpSpec> Ops;

            [MethodImpl(Inline)]
            public InstPatternSpec(uint id, uint instid, IClass @class, string rawbody, InstPatternBody body, OpSpec[] ops)
            {
                PatternId = id;
                InstId = instid;
                Class = @class;
                Body = body;
                RawBody = rawbody;
                BodyExpr = XedRender.format(body);
                Ops = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithOps(OpSpec[] src)
                => new InstPatternSpec(PatternId, InstId, Class, BodyExpr, Body, src);

            [MethodImpl(Inline)]
            public InstPatternSpec WithInstId(uint src)
                => new InstPatternSpec(PatternId, src, Class, BodyExpr, Body, Ops);

            [MethodImpl(Inline)]
            public InstPatternSpec WithClass(IClass src)
                => new InstPatternSpec(PatternId, InstId, src, BodyExpr, Body, Ops);
            public int CompareTo(InstPatternSpec src)
            {
                var result = InstId.CompareTo(src.InstId);
                if(result == 0)
                    result = BodyExpr.CompareTo(src.BodyExpr);
                return result;
            }

            public string Format()
                => string.Format("Expression:{0}\nOperands:{1}", BodyExpr, Ops);

            public override string ToString()
                => Format();
        }
    }
}