//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels.BCastKind;
    using static Asm.AsmBroadcastClass;
    using W = XedModels.OperandWidthKind;

    partial struct XedModels
    {
        public static NativeSize size(OperandWidthKind src)
        {
            var result = default(NativeSize);
            switch(src)
            {
                case W.B:
                case W.I8:
                case W.U8:
                    result = NativeSizeCode.W8;
                    break;
                case W.W:
                case W.I16:
                case W.U16:
                case W.F16:
                case W.WRD:
                    result = NativeSizeCode.W16;
                    break;
                case W.D:
                case W.F32:
                case W.I32:
                case W.U32:
                case W.Z:
                    result = NativeSizeCode.W32;
                    break;
                case W.Q:
                case W.F64:
                case W.I64:
                case W.U64:
                case W.MSKW:
                case W.MB:
                case W.MW:
                case W.MD:
                case W.MQ:
                case W.V:
                case W.Y:
                case W.SD:
                    result = NativeSizeCode.W64;
                    break;
                case W.F80:
                    result  = NativeSizeCode.W80;
                    break;
                case W.DQ:
                case W.X128:
                case W.XB:
                case W.XW:
                case W.XD:
                case W.XQ:
                case W.XUB:
                case W.XUW:
                case W.XUD:
                case W.XUQ:
                case W.PS:
                case W.PD:
                    result = NativeSizeCode.W128;
                    break;
                case W.YB:
                case W.YW:
                case W.YD:
                case W.YQ:
                case W.YUB:
                case W.YUW:
                case W.YUD:
                case W.YUQ:
                case W.QQ:
                case W.Y128:
                    result = NativeSizeCode.W256;
                break;
                case W.ZB:
                case W.ZW:
                case W.ZD:
                case W.ZQ:
                case W.ZMSKW:
                case W.ZF32:
                case W.ZF64:
                case W.ZUB:
                case W.ZU8:
                case W.ZU16:
                case W.ZU32:
                case W.ZU64:
                case W.ZI8:
                case W.ZI16:
                case W.ZI32:
                case W.ZI64:
                    result = NativeSizeCode.W512;
                break;
            }
            return result;
        }
        [Op]
        public AsmBroadcastInfo BroadcastSpec(BCastKind kind)
        {
            var dst = AsmBroadcastInfo.Empty;
            var id = (uint5)(byte)kind;
            switch(kind)
            {
                case BCast_1TO16_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO16_8).Format(), 1, 16);
                break;

                case BCast_1TO32_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO32_8).Format(), 1, 32);
                break;

                case BCast_1TO64_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO64_8).Format(), 1, 64);
                break;

                case BCast_1TO2_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO2_8).Format(), 1, 8);
                break;

                case BCast_1TO4_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO4_8).Format(), 1, 4);
                break;

                case BCast_1TO8_8:
                    dst = AsmBroadcastInfo.define(id, BCast8, Symbols.expr(BCast8Kind.BCast_1TO8_8).Format(), 1, 8);
                break;

                case BCast_1TO8_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO8_16).Format(), 1, 8);
                break;

                case BCast_1TO16_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO16_16).Format(), 1, 16);
                break;

                case BCast_1TO32_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO32_16).Format(), 1, 32);
                break;

                case BCast_1TO2_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO2_16).Format(), 1, 2);
                break;

                case BCast_1TO4_16:
                    dst = AsmBroadcastInfo.define(id, BCast16, Symbols.expr(BCast16Kind.BCast_1TO4_16).Text, 1, 4);
                break;

                case BCast_1TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO16_32).Text, 1, 16);
                break;

                case BCast_4TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_4TO16_32).Text, 4, 16);
                break;

                case BCast_1TO8_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO8_32).Text, 1, 8);
                break;

                case BCast_4TO8_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_4TO8_32).Text, 4, 8);
                break;

                case BCast_2TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_2TO16_32).Text, 2, 16);
                break;

                case BCast_8TO16_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_8TO16_32).Text, 8, 16);
                break;

                case BCast_1TO4_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO4_32).Text, 1, 4);
                break;

                case BCast_2TO4_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_2TO4_32).Text, 2, 4);
                break;

                case BCast_2TO8_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_2TO8_32).Text, 2, 8);
                break;

                case BCast_1TO2_32:
                    dst = AsmBroadcastInfo.define(id, BCast32, Symbols.expr(BCast32Kind.BCast_1TO2_32).Text, 1, 2);
                break;

                case BCast_1TO8_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_1TO8_64).Text, 1, 8);
                break;

                case BCast_4TO8_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_4TO8_64).Text, 4, 8);
                break;

                case BCastKind.BCast_2TO8_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_2TO8_64).Text, 2, 8);
                break;

                case BCastKind.BCast_1TO2_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_1TO2_64).Text, 1, 2);
                break;

                case BCastKind.BCast_1TO4_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_1TO4_64).Text, 1, 4);
                break;

                case BCastKind.BCast_2TO4_64:
                    dst = AsmBroadcastInfo.define(id, BCast64, Symbols.expr(BCast64Kind.BCast_2TO4_64).Text, 2, 64);
                break;
            }

            return dst;
        }
    }
}