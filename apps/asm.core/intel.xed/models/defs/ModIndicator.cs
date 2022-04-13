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

            [Symbol("mm")]
            ANY,

            [Symbol("0b00")]
            MOD0,

            [Symbol("0b01")]
            MOD1,

            [Symbol("0b10")]
            MOD2,

            [Symbol("0b**")]
            NE3,

            [Symbol("0b11")]
            MOD3,
        }
    }
}