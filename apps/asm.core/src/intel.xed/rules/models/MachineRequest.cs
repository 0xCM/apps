//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct MachineRequest
        {
            public readonly RequestKind Kind;

            public readonly RuleDef Rule;

            [MethodImpl(Inline)]
            public MachineRequest(RequestKind kind, RuleDef rule)
            {
                Kind = kind;
                Rule = rule;
            }
        }
    }
}