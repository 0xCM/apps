//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [DataWidth(2)]
        public enum RuleTableKind : byte
        {
            None = 0,

            [Symbol("enc")]
            ENC = 1,

            [Symbol("dec")]
            DEC = 2,
        }
    }
}