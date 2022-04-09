//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;
    using static XedModels;

    using S = XedPatterns.OpCodeSymbols;

    partial class XedPatterns
    {
        [Op]
        public static string symbol(OpCodeKind src)
            => src switch
            {
                Base00 => S.B0,
                Base0F => S.B1,
                Base0F38 => S.B2,
                Base0F3A => S.B3,
                Amd3DNow => S.D3,
                Xop8 => S.X8,
                Xop9 => S.X9,
                XopA => S.XA,
                Vex0F => S.V1,
                Vex0F38 => S.V2,
                Vex0F3A => S.V3,
                Evex0F => S.E1,
                Evex0F38 => S.E2,
                Evex0F3A => S.E3,

                _ => EmptyString
            };
    }
}