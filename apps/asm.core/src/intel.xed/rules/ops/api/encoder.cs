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
        public static Encoder encoder()
            => Encoder.create();

        public static Encoder encoder(MachineRequest request)
            => Encoder.create(request);

        public static Encoder encoder(RulePattern rule, params RuleOperand[] ops)
            => Encoder.create(request(RequestKind.Encode, rule,ops));
    }
}