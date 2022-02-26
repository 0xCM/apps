//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using OCP = XedModels.OcPatternNames;

    partial struct XedModels
    {
        [SymSource(xed_state)]
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