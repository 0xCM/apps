//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-state-bits.txt
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