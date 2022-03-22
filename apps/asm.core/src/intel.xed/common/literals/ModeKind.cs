//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(2)]
        public enum ModeKind : sbyte
        {
            [Symbol("16", "MODE=0")]
            Mode16 = 0,

            [Symbol("32", "MODE=1")]
            Mode32 = 1,

            [Symbol("64", "MODE=2")]
            Mode64 = 2,

            [Symbol("16/32", "MODE!=2")]
            Not64 = 3,
        }
    }
}