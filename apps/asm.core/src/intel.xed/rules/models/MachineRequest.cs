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
        public enum RequestKind : byte
        {
            Encode,

            Decode
        }

        public readonly struct MachineRequest
        {
            public readonly RequestKind Kind;

            public readonly RulePattern Rule;

            public readonly Index<RuleOperand> Operands;

            [MethodImpl(Inline)]
            public MachineRequest(RequestKind kind, RulePattern rule, Index<RuleOperand> ops)
            {
                Kind = kind;
                Rule = rule;
                Operands = ops;
            }
        }
    }
}