//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.OpCodeKind;

    partial class XedPatterns
    {
        public static asci4 selector(OpCodeKind src)
            => src switch {
                Base00 => "0000",
                Base0F => "000F",
                Base0F38 => "0F38",
                Base0F3A => "0F3A",
                Amd3DNow => "003D",
                Xop8 => "0008",
                Xop9 => "0009",
                XopA => "000A",
                Vex0F => "000F",
                Vex0F38 => "0F38",
                Vex0F3A => "0F3A",
                Evex0F => "000F",
                Evex0F38 => "0F38",
                Evex0F3A => "0F3A",
                _ => asci4.Null,
            };
    }
}