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
        [SymSource(xed), DataWidth(num5.PackedWidth)]
        public enum OpCodeClass : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol(N.BaseMapClass)]
            Base = 1,

            [Symbol(N.XopMapClass)]
            Xop = 2,

            [Symbol(N.VexMapClass)]
            Vex = 4,

            [Symbol(N.EvexMapClass)]
            Evex = 8,

            [Symbol(N.Amd3dMapClass)]
            Amd3D = 16,
        }
    }
}