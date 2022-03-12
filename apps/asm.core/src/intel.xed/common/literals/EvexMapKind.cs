//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum EvexMapKind : byte
        {
            [Symbol("Evex0F", "MAP=1")]
            EVEX_MAP_0F=1,

            [Symbol("Evex0F38", "MAP=2")]
            EVEX_MAP_0F38=2,

            [Symbol("Evex0F3A", "MAP=3")]
            EVEX_MAP_0F3A=3,
        }
    }
}