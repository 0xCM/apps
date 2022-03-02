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
        public static MachineRequest request(RequestKind kind, RulePattern rule, params RuleOperand[] ops)
            => new MachineRequest(kind,rule,ops);
    }
}