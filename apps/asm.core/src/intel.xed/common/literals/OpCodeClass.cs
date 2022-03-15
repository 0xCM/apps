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
        [SymSource(xed)]
        public enum OpCodeClass : byte
        {
            None = 0,

            [Symbol(N.LegacyMapClass)]
            LEGACY = 1,

            [Symbol(N.XopMapClass)]
            XOP = 2,

            [Symbol(N.VexMapClass)]
            VEX = 4,

            [Symbol(N.EvexMapClass)]
            EVEX = 8,
        }
    }
}