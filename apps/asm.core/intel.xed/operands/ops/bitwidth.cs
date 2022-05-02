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
    using static XedModels.ModeClass;

    partial class XedOperands
    {
        [Op]
        public static ushort bitwidth(XedRegId src)
            => (ushort)XedRegMap.Service.Map(src).Size.Width;

        [Op]
        public static ushort bitwidth(VexLength src)
            => src switch
            {
                VexLength.VL128 => 128,
                VexLength.VL256 => 256,
                VexLength.VL512 => 512,
                _ => 0
            };

        [Op]
        public static ushort bitwidth(OSZ src)
            => src switch
            {
                OSZ.o16=> 16,
                OSZ.o32=> 32,
                OSZ.o64=> 64,
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
        public static uint bitwidth(ModeClass src)
            => src switch
            {
                Mode16 => 16,
                Mode32 => 32,
                Mode64 => 64,
                _ => 0,
            };
    }
}