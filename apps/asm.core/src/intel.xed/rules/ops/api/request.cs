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
        [MethodImpl(Inline), Op]
        public static MachineRequest request(RequestKind kind, RulePattern rule, params RuleOperand[] ops)
            => new MachineRequest(kind, XedRules.rule(rule, ops));

        [MethodImpl(Inline), Op]
        public static MachineRequest request(RequestKind kind, RuleDef rule)
            => new MachineRequest(kind, rule);
    }
}