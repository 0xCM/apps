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
        public static Encoder encoder()
            => Encoder.create();

        public static Encoder encoder(MachineRequest request)
            => Encoder.create(request);

        public static Encoder encoder(RulePatternInfo rule, params RuleOp[] ops)
            => Encoder.create(request(RequestKind.Encode, rule,ops));
    }
}