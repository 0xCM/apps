//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline)]
        public static RuleMachine machine()
            => RuleMachine.create();

        [MethodImpl(Inline)]
        public static RuleMachine machine(in RuleState src)
            => RuleMachine.create(src);
    }
}