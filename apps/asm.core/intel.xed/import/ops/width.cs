//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using EK = XedModels.ElementKind;
    using WC = XedModels.OpWidthCode;

    partial class XedImport
    {
        public static OpWidth width(MachineMode mode, OpWidthCode code)
        {
            var dst = OpWidth.Empty;
            if(code == 0)
                return dst;
            else if(_OpWidthLookup.Find(code, out var info))
            {
                switch(mode.Class)
                {
                    case ModeClass.Mode16:
                        dst = new OpWidth(code, info.Width16);
                    break;
                    case ModeClass.Not64:
                    case ModeClass.Mode32:
                        dst = new OpWidth(code, info.Width32);
                    break;

                    default:
                        dst = new OpWidth(code, info.Width64);
                    break;
                }
            }
            else
                Errors.Throw(code.ToString());
            return dst;
        }

        [MethodImpl(Inline)]
        public static OpWidthRecord describe(OpWidthCode code)
            => code == 0 ? OpWidthRecord.Empty : _OpWidthLookup[code];

        public static ushort width(OpWidthCode code, ElementKind ekind)
        {
            var result = width(code);
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

        static ushort width(OpWidthCode code)
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
    }
}