//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.OpCodeKind;
    using static XedModels;

    using I = XedModels.OpCodeIndex;

    partial class XedPatterns
    {
        [Op]
        public static OpCodeKind ockind(OpCodeIndex src)
            => src switch {
                I.LegacyMap0 => Base00,
                I.LegacyMap1 => Base0F,
                I.LegacyMap2 => Base0F38,
                I.LegacyMap3 => Base0F3A,
                I.Amd3dNow => Amd3DNow,
                I.Xop8 => Xop8,
                I.Xop9 => Xop9,
                I.XopA => XopA,
                I.Vex0F => Vex0F,
                I.Vex0F38 => Vex0F38,
                I.Vex0F3A => Vex0F3A,
                I.Evex0F => Evex0F,
                I.Evex0F38 => Evex0F38,
                I.Evex0F3A => Evex0F3A,
                _=> OpCodeKind.None
            };
    }
}