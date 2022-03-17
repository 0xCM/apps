//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(3)]
        public enum RuleTableKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("enc")]
            Enc = 1,

            [Symbol("dec")]
            Dec = 2,

            [Symbol("encdec")]
            EncDec = 3,
        }
    }
}