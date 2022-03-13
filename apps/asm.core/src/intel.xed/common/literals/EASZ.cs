//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed_state), DataWidth(3)]
        public enum EASZ : sbyte
        {
            None = 0,

            [Symbol("eamode16", "EASZ=1")]
            EASZ16 = 1,

            [Symbol("eamode32", "EASZ=2")]
            EASZ32 = 2,

            [Symbol("eamode64", "EASZ=3")]
            EASZ64 = 3,

            [Symbol("eanot16", "EASZ!=1")]
            EASZNot16 = 4,
        }
    }
}