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
        public enum ModKind : byte
        {
            [Symbol("mod0","MOD=0")]
            MOD0 = 0,

            [Symbol("mod1","MOD=1")]
            MOD1 = 1,

            [Symbol("mod2","MOD=2")]
            MOD2 = 2,

            [Symbol("mod3","MOD=3")]
            MOD3 = 3
        }
    }
}