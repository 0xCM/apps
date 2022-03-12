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
        public enum VexMapKind : byte
        {
            [Symbol("Vex0F", "MAP=1")]
            VEX_MAP_0F = 1,

            [Symbol("Vex0F38", "MAP=2")]
            VEX_MAP_0F38 = 2,

            [Symbol("Vex0F3A", "MAP=3")]
            VEX_MAP_0F3A = 3
        }
    }
}