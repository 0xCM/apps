//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        /// <summary>
        /// Stack addressing mode
        /// </summary>
        [SymSource(xed_state), DataWidth(2)]
        public enum SMode : sbyte
        {
            [Symbol("smode16", "SMODE=0")]
            SMode16 = 0,

            [Symbol("smode32","SMODE=1")]
            SMode32= 1,

            [Symbol("smode64","SMODE=2")]
            SMode64 = 2
        }
    }
}