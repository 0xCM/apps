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
            None,

            Enc = 1,

            Dec = 2,

            EncDec = 3,

            Joined = 4
        }
    }
}