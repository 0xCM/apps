//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels.EASZ;
    using static XedModels.EOSZ;
    using static XedModels.ModeKind;

    using EK = XedModels.ElementKind;
    using OK = XedModels.OpWidthCode;

    partial struct XedModels
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

        [Op]
        public static ushort bitwidth(PointerWidthKind src)
            => src switch
            {
                PointerWidthKind.Byte => 8,
                PointerWidthKind.Word => 16,
                PointerWidthKind.DWord => 32,
                PointerWidthKind.QWord => 64,
                PointerWidthKind.XmmWord => 128,
                PointerWidthKind.YmmWord => 256,
                PointerWidthKind.ZmmWord => 512,
                _ => 0
            };

        [Op]
        public static ushort bitwidth(OpWidthCode okind, ElementKind ekind)
        {
            var result = z16;
            switch(okind)
            {
                case OK.MSKW:
                case OK.ZMSKW:
                case OK.I1:
                    result = 1;
                break;
                case OK.I2:
                    result = 2;
                break;
                case OK.I3:
                    result = 3;
                break;
                case OK.I4:
                    result = 4;
                break;
                case OK.I5:
                    result = 5;
                break;
                case OK.I6:
                    result = 6;
                break;
                case OK.I7:
                    result = 7;
                break;

                case OK.MEM16:
                case OK.MEM16INT:
                    result = 16;
                    break;

                case OK.MEM28:
                    result = 224;
                    break;

                case OK.MEM14:
                    result=112;
                break;

                case OK.MEM94:
                    result=94;
                break;

                case OK.MEM108:
                    result=108;
                break;

                case OK.M512:
                    result = 512;
                    break;

                case OK.M384:
                    result = 384;
                    break;

                case OK.MFPXENV:
                    result = 4096;
                break;

                case OK.MXSAVE:
                    result = 4608;
                break;
            }

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