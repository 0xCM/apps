//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed), DataWidth(4), Flags]
        public enum Addressing : byte
        {
            [Symbol("")]
            None=0,

            [Symbol("16b", "16b addressing")]
            w16b=2,

            [Symbol("32b", "32b addressing")]
            w32b=4,

            [Symbol("64b", "64b addressing")]
            w64b=8,
        }
    }
}