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

    using EK = XedModels.ElementKind;
    using WC = XedModels.OpWidthCode;

    partial class XedOperands
    {
        public static ushort bitwidth(OpWidthCode code, ElementKind ekind)
        {
            var result = bitwidth(code);
            if(result != 0)
                return result;

            switch(ekind)
            {
                case EK.U8:
                case EK.I8:
                    result = 8;
                    break;

                case EK.U16:
                case EK.I16:
                case EK.F16:
                case EK.BF16:
                    result = 16;
                    break;

                case EK.U32:
                case EK.I32:
                case EK.F32:
                case EK.INT:
                case EK.UINT:
                    result = 32;
                    break;

                case EK.U64:
                case EK.I64:
                case EK.F64:
                    result = 64;
                    break;

                case EK.B80:
                case EK.F80:
                    result = 80;
                    break;

                case EK.U128:
                    result = 128;
                    break;

                case EK.U256:
                    result = 256;
                    break;
                default:
                break;
            }

            return result;
        }

        static ushort bitwidth(OpWidthCode code)
        {
            var result = z16;
            switch(code)
            {
                case WC.B:
                    result = 8;
                break;

                case WC.D:
                    result = 32;
                break;

                case WC.MSKW:
                case WC.ZMSKW:
                case WC.I1:
                    result = 1;
                break;
                case WC.I2:
                    result = 2;
                break;
                case WC.I3:
                    result = 3;
                break;
                case WC.I4:
                    result = 4;
                break;
                case WC.I5:
                    result = 5;
                break;
                case WC.I6:
                    result = 6;
                break;
                case WC.I7:
                    result = 7;
                break;
                case WC.I8:
                    result = 8;
                break;

                case WC.MEM16:
                case WC.MEM16INT:
                    result = 16;
                    break;

                case WC.MEM28:
                    result = 224;
                    break;

                case WC.MEM14:
                    result=112;
                break;

                case WC.MEM94:
                    result=94;
                break;

                case WC.MEM108:
                    result=108;
                break;

                case WC.M512:
                    result = 512;
                    break;

                case WC.M384:
                    result = 384;
                    break;

                case WC.MFPXENV:
                    result = 4096;
                break;

                case WC.MXSAVE:
                    result = 4608;
                break;
            }

            return result;
        }

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