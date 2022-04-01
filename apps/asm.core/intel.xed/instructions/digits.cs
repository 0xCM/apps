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
        public static string digits(OpCodeKind src)
            => src switch {
                Base00 => "00",
                Base0F => "0F",
                Base0F38 => "0F38",
                Base0F3A => "0F3A",
                Amd3DNow => "3D",
                Xop8 => "08",
                Xop9 => "09",
                XopA => "0A",
                Vex0F => "0F",
                Vex0F38 => "0F38",
                Vex0F3A => "0F3A",
                Evex0F => "0F",
                Evex0F38 => "0F38",
                Evex0F3A => "0F3A",
                _ => EmptyString,
            };
    }
}