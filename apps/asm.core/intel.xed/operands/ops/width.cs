//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.ModeClass;
    using static XedModels.DispWidth;

    partial class XedOperands
    {
        [Op]
        public static ushort width(XedRegId src)
            => (ushort)XedRegMap.Service.Map(src).Size.Width;

        [Op]
        public static ushort width(VexLength src)
            => src switch
            {
                VexLength.VL128 => 128,
                VexLength.VL256 => 256,
                VexLength.VL512 => 512,
                _ => 0
            };

        [Op]
        public static ushort width(OSZ src)
            => src switch
            {
                OSZ.o16=> 16,
                OSZ.o32=> 32,
                OSZ.o64=> 64,
                _ => 0
            };

        [MethodImpl(Inline)]
        public static ushort width(PointerWidthKind src)
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
        public static uint width(EASZ src)
            => src switch
            {
                EASZ16 => 16,
                EASZ32 => 32,
                EASZ64 => 64,
                _ => 0,
            };

        [Op]
        public static uint width(ModeClass src)
            => src switch
            {
                Mode16 => 16,
                Mode32 => 32,
                Mode64 => 64,
                _ => 0,
            };


        [Op]
        public static uint width(DispWidth src)
            => src switch
            {
                DW8 => 8,
                DW16 => 16,
                DW32 => 32,
                DW64 => 64,
                _ => 0,
            };
    }
}