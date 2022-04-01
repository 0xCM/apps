//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource("xed"),DataWidth(3)]
        public enum ModIndicator : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("MOD[mm]","mm")]
            ANY,

            [Symbol("MOD=0","0b00")]
            MOD0,

            [Symbol("MOD=1","0b01")]
            MOD1,

            [Symbol("MOD=2","0b10")]
            MOD2,

            [Symbol("MOD!=3","0b00,0b01,0b10")]
            NE3,

            [Symbol("MOD=3","0b11")]
            MOD3,
        }
    }
}