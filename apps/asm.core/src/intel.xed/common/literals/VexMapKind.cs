//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = XedNames;

    partial struct XedModels
    {
        [SymSource(xed_state), DataWidth(2)]
        public enum VexMapKind : byte
        {
            [Symbol(N.VexMap1Name, "MAP=1")]
            VEX_MAP_0F = 1,

            [Symbol(N.VexMap2Name, "MAP=2")]
            VEX_MAP_0F38 = 2,

            [Symbol(N.VexMap3Name, "MAP=3")]
            VEX_MAP_0F3A = 3
        }
    }
}