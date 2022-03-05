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
        public enum XopMapKind : byte
        {
            [Symbol("Xop8", OCP.XopPattern8)]
            XOP8=8,

            [Symbol("Xop9", OCP.XopPattern9)]
            XOP9=9,

            [Symbol("XopA", OCP.XopPatternA)]
            XOPA=10,
        }
    }
}