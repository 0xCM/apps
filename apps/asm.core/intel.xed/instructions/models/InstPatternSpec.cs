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

            public readonly MachineMode Mode;

            public readonly InstClass InstClass;

            public readonly InstForm InstForm;

            public readonly XedOpCode OpCode;

            public readonly TextBlock BodyExpr;

            public readonly TextBlock RawBody;

            public readonly InstPatternBody Body;

            public readonly Index<OpSpec> Ops;

            [MethodImpl(Inline)]
            public InstPatternSpec(uint id, uint instid, InstClass @class, InstForm form, XedOpCode opcode, string rawbody, InstPatternBody body, string bodyexpr, OpSpec[] ops)
            {
                PatternId = id;
                InstId = instid;
                Mode = mode(body);
                InstClass = @class;
                InstForm = form;
                OpCode = opcode;
                Body = body;
                RawBody = rawbody;
                BodyExpr = bodyexpr;
                Ops = ops;
            }

            [MethodImpl(Inline)]
            public InstPatternSpec WithForm(InstForm src)
                => new InstPatternSpec(PatternId, InstId, InstClass, src, OpCode, RawBody, Body, BodyExpr, Ops);

            [MethodImpl(Inline)]
            public InstPatternSpec WithIdentity(uint pattern, uint inst)
                => new InstPatternSpec(pattern, inst, InstClass, InstForm, OpCode, RawBody, Body, BodyExpr, Ops);

            public int CompareTo(InstPatternSpec src)
            {
                var result = InstId.CompareTo(src.InstId);
                if(result == 0)
                {
                    result = InstClass.CompareTo(src.InstClass);
                    if(result == 0)
                    {
                        result = OpCode.CompareTo(src.OpCode);
                        if(result == 0)
                        {
                            if(InstForm.IsNonEmpty)
                                result = InstForm.CompareTo(src.InstForm);
                            if(result == 0)
                                result = BodyExpr.CompareTo(src.BodyExpr);
                        }
                    }
                }
                return result;
            }

            [MethodImpl(Inline)]
            public PatternSort Sort()
                => new PatternSort(this);
        }
    }
}