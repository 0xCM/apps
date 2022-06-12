//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = AsmOpCodeMaps.Literals;

    [SymSource(AsmOpCodeMaps.group), DataWidth(num4.Width)]
    public enum XopMapKind : byte
    {
        [Symbol(N.X8)]
        Xop8=8,

        [Symbol(N.X9)]
        Xop9=9,

        [Symbol(N.XA)]
        XopA=10,
    }   
}