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
        public enum XopMapKind : byte
        {
            [Symbol(N.XopMap8Name)]
            Xop8=8,

            [Symbol(N.XopMap9Name)]
            Xop9=9,

            [Symbol(N.XopMapAName)]
            XopA=10,
        }
    }
}