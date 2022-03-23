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

            public readonly ModeKind Mode;

            public readonly IClass Class;

            public readonly XedOpCode OpCode;

            public readonly TextBlock BodyExpr;

            public readonly TextBlock RawBody;

            public readonly InstPatternBody Body;

            public readonly Index<OpSpec> Ops;

            [MethodImpl(Inline)]
            public InstPatternSpec(uint id, uint instid, IClass @class, XedOpCode opcode, string rawbody, InstPatternBody body, OpSpec[] ops)
            {
                PatternId = id;
                InstId = instid;
                Mode = mode(body);
                Class = @class;
                OpCode = opcode;
                Body = body;
                RawBody = rawbody;
                BodyExpr = XedRender.format(body);
                Ops = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithInstId(uint src)
                => new InstPatternSpec(PatternId, src, Class, OpCode, BodyExpr, Body, Ops);

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