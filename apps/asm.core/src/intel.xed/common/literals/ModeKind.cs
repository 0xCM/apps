//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed_state), DataWidth(2)]
        public enum ModeKind : sbyte
        {
            [Symbol("mode16", "MODE=0")]
            Mode16 = 0,

            [Symbol("mode32", "MODE=1")]
            Mode32 = 1,

            [Symbol("mode64", "MODE=2")]
            Mode64 = 2,

            [Symbol("not64", "MODE!=2")]
            Not64 = 3,
        }
    }
}