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
                LEGACY_00 => S.L0,
                LEGACY_0F => S.L1,
                LEGACY_0F38 => S.L2,
                LEGACY_0F3A => S.L3,
                AMD_3DNOW => S.D3,
                XOP8 => S.X8,
                XOP9 => S.X9,
                XOPA => S.XA,
                VEX_0F => S.V1,
                VEX_0F38 => S.V2,
                VEX_0F3A => S.V3,
                EVEX_0F => S.E1,
                EVEX_0F38 => S.E2,
                EVEX_0F3A => S.E3,

                _ => EmptyString
            };
    }
}