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

            public readonly IForm Form;

            public readonly XedOpCode OpCode;

            public readonly TextBlock BodyExpr;

            public readonly TextBlock RawBody;

            public readonly InstPatternBody Body;

            public readonly Index<OpSpec> Ops;

            [MethodImpl(Inline)]
            public InstPatternSpec(uint id, uint instid, IClass @class, IForm form, XedOpCode opcode, string rawbody, InstPatternBody body, string bodyexpr, OpSpec[] ops)
            {
                PatternId = id;
                InstId = instid;
                Mode = mode(body);
                Class = @class;
                Form = form;
                OpCode = opcode;
                Body = body;
                RawBody = rawbody;
                BodyExpr = bodyexpr;
                Ops = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithInstId(uint src)
                => new InstPatternSpec(PatternId, src, Class, Form, OpCode, RawBody, Body, BodyExpr, Ops);

            [MethodImpl(Inline)]
            public InstPatternSpec WithForm(IForm src)
                => new InstPatternSpec(PatternId, InstId, Class, src, OpCode, RawBody, Body, BodyExpr, Ops);

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