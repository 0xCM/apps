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
        [SymSource(xed), DataWidth(3)]
        public enum VexClass : byte
        {
            [Symbol(N.VV0, "VEXVALID=0")]
            VV0 = 0,

            [Symbol(N.VV1, "VEXVALID=1")]
            VV1 = 1,

            [Symbol(N.EVV, "VEXVALID=2")]
            EVV = 2,

            [Symbol(N.XOPV, "VEXVALID=3")]
            XOPV = 3,

            [Symbol(N.KVV, "VEXVALID=4, KNC EVEX")]
            KVV = 4,
        }
    }
}