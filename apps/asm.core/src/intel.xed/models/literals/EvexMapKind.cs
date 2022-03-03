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
        [SymSource(xed)]
        public enum EvexMapKind : byte
        {
            [Symbol("evex-map1", OCP.EvexPattern0F)]
            EVEX_MAP_0F=1,

            [Symbol("evex-map2", OCP.EvexPattern0F38)]
            EVEX_MAP_0F38=2,

            [Symbol("evex-map3", OCP.EvexPattern0F3A)]
            EVEX_MAP_0F3A=3,
        }
    }
}