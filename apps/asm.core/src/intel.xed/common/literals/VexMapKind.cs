//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using OCP = XedModels.OcPatternNames;

    partial struct XedModels
    {
        [SymSource(xed_state), DataWidth(2)]
        public enum VexMapKind : byte
        {
            [Symbol("Vex0F", OCP.VexPattern0F)]
            VEX_MAP_0F = 1,

            [Symbol("Vex0F38", OCP.VexPattern0F38)]
            VEX_MAP_0F38 = 2,

            [Symbol("Vex0F3A", OCP.VexPattern0F3A)]
            VEX_MAP_0F3A = 3
        }
    }
}