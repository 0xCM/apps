//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.ModeKind;

    partial class XedPatterns
    {
        [Op]
        public static ushort bitwidth(XedRegId src)
            => (ushort)XedRegMap.Service.Map(src).Size.Width;

        [Op]
        public static ushort bitwidth(VexLengthKind src)
            => src switch
            {
                VexLengthKind.VL128 => 128,
                VexLengthKind.VL256 => 256,
                VexLengthKind.VL512 => 512,
                _ => 0
            };

        [MethodImpl(Inline)]
        public static ushort bitwidth(PointerWidthKind src)
            => src == 0 ? z16 : (ushort)((ushort)src * 8);

        [Op]
        public static uint bitwidth(EOSZ src)
            => src switch
            {
                EOSZ8 => 8,
                EOSZ16 => 16,
                EOSZ32 => 32,
                EOSZ64 => 64,
                _ => 0,
            };


        [Op]
        public static uint bitwidth(EASZ src)
            => src switch
            {
                EASZ16 => 16,
                EASZ32 => 32,
                EASZ64 => 64,
                _ => 0,
            };

        [Op]
        public static uint bitwidth(ModeKind src)
            => src switch
            {
                Mode16 => 16,
                Mode32 => 32,
                Mode64 => 64,
                _ => 0,
            };
    }
}