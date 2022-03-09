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
    using OK = XedModels.OperandWidthKind;

    partial struct XedModels
    {
        [Op]
        public static ushort width(OperandWidthKind src)
        {
            var dst = z16;
            switch(src)
            {

                case OK.B:
                case OK.I8:
                case OK.U8:
                    dst = 8;
                    break;

                case OK.W:
                case OK.I16:
                case OK.U16:
                case OK.F16:
                case OK.WRD:
                    dst = 16;
                    break;

                case OK.D:
                case OK.F32:
                case OK.I32:
                case OK.U32:
                case OK.Z:
                    dst = 32;
                    break;

                case OK.Q:
                case OK.F64:
                case OK.I64:
                case OK.U64:
                case OK.MB:
                case OK.MW:
                case OK.MD:
                case OK.MQ:
                case OK.V:
                case OK.Y:
                case OK.SD:
                case OK.MSKW:
                    dst = 64;
                    break;

                case OK.F80:
                    dst  = 80;
                    break;

                case OK.DQ:
                case OK.X128:
                case OK.XB:
                case OK.XW:
                case OK.XD:
                case OK.XQ:
                case OK.XUB:
                case OK.XUW:
                case OK.XUD:
                case OK.XUQ:
                case OK.PS:
                case OK.PD:
                    dst = 128;
                    break;

                case OK.YB:
                case OK.YW:
                case OK.YD:
                case OK.YQ:
                case OK.YUB:
                case OK.YUW:
                case OK.YUD:
                case OK.YUQ:
                case OK.QQ:
                case OK.Y128:
                    dst = 256;
                break;
                case OK.ZB:

                case OK.ZW:
                case OK.ZD:
                case OK.ZQ:
                case OK.ZF32:
                case OK.ZF64:
                case OK.ZUB:
                case OK.ZU8:
                case OK.ZU16:
                case OK.ZU32:
                case OK.ZU64:
                case OK.ZI8:
                case OK.ZI16:
                case OK.ZI32:
                case OK.ZI64:
                case OK.ZMSKW:
                    dst = 512;
                break;
            }
            return dst;
        }

        [Op]
        public static ushort width(OperandWidthKind okind, ElementKind ekind)
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
        public static uint width(EOSZ src)
            => src switch
            {
                EOSZ8 => 8,
                EOSZ16 => 16,
                EOSZ32 => 32,
                EOSZ64 => 64,
                _ => 0,
            };

        [Op]
        public static uint widths(EOSZ src)
            => src switch
            {
                EOSZ8 => 8,
                EOSZ16 => 16,
                EOSZ32 => 32,
                EOSZ64 => 64,
                EOSZNot16 => 8 | (32 << 8) | (64 << 16),
                EOSZNot64 => 8 | (16 << 8) | (32 << 16),
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
        public static uint width(ModeKind src)
            => src switch
            {
                Mode16 => 16,
                Mode32 => 32,
                Mode64 => 64,
                _ => 0,
            };

        [Op]
        public static uint widths(ModeKind src)
            => src switch
            {
                Mode16 => 16,
                Mode32 => 32,
                Mode64 => 64,
                Not64 => 16 | 32,
                _ => 0,
            };

        [Op]
        public static uint widths(EASZ src)
            => src switch
            {
                EASZ16 => 16,
                EASZ32 => 32,
                EASZ64 => 64,
                EASZNot16 => 32 | (64 << 8),
                _ => 0,
            };
    }
}