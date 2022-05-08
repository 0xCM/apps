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
        [SymSource(xed), DataWidth(num2.Width)]
        public enum EvexMapKind : byte
        {
            [Symbol(N.EvexMap1Name, "MAP=1")]
            EVEX_MAP_0F=1,

            [Symbol(N.EvexMap2Name, "MAP=2")]
            EVEX_MAP_0F38=2,

            [Symbol(N.EvexMap3Name, "MAP=3")]
            EVEX_MAP_0F3A=3,
        }
    }
}