//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static core;

    using R = XedRules;
    using C = XedRules.FormatCode;
    using K = XedRules.FieldKind;

    partial class XedFields
    {
        public static string format(R.FieldValue src)
        {
            var dst = EmptyString;
            if(src.IsEmpty)
                return EmptyString;

            var data = bytes(src.Data);
            var code = XedFields.fcode(src.Field);

            switch(src.Field)
            {
                case K.MASK:
                {
                    var x = @as<MASK>(data);
                    dst = XedRender.format(x,code);
                    if(code == FormatCode.Expr)
                        dst = text.embrace(dst);
                }
                break;
                // case K.ZEROING:
                // {
                //     dst = "{z}";
                // }
                // break;
                case K.EASZ:
                {
                    var x = @as<EASZ>(data);
                    dst = XedRender.format(x, code);
                }
                break;
                case K.EOSZ:
                {
                    var x = @as<EOSZ>(data);
                    dst = XedRender.format(x, code);
                }
                break;
                case K.MODE:
                {
                    var x = @as<ModeKind>(data);
                    dst = XedRender.format(x, code);
                }
                break;
                case K.SMODE:
                {
                    var x = @as<SMode>(data);
                    dst = XedRender.format(x, code);
                }
                break;
                case K.VEXVALID:
                {
                    var x = @as<VexClass>(data);
                    dst = XedRender.format(x, code);
                }
                break;
                case K.VEX_PREFIX:
                {
                    var x = @as<VexKind>(data);
                    dst = XedRender.format(x, code);
                }
                break;
            }

            if(nonempty(dst))
                return dst;

            switch(code)
            {
                case C.A8:
                {
                    asci8 x = src.Data;
                    dst = x.Format();
                }
                break;
                case C.Text:
                    dst = ((NameResolver)((int)src.Data)).Format();
                    break;
                case C.Bit:
                {
                    bit x = first(data);
                    dst = x.Format();
                }
                break;
                case C.B1:
                {
                    uint1 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.B2:
                {
                    uint2 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.B3:
                {
                    uint3 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.B4:
                {
                    uint4 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.B5:
                {
                    uint5 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.B6:
                {
                    uint6 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.B7:
                {
                    uint7 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.B8:
                {
                    uint8b x = first(data);
                    dst = XedRender.format(x);
                }
                break;

                case C.U1:
                {
                    byte x = (byte)(first(data) & 0b1);
                    dst = format(x);
                }
                break;

                case C.U2:
                {
                    byte x = (byte)(first(data) & 0b11);
                    dst = format(x);
                }
                break;

                case C.U3:
                {
                    byte x = (byte)(first(data) & 0b111);
                    dst = format(x);
                }
                break;

                case C.U4:
                {
                    byte x = (byte)(first(data) & 0b1111);
                    dst = format(x);
                }
                break;

                case C.U5:
                {
                    byte x = (byte)(first(data) & 0b11111);
                    dst = format(x);
                }
                break;

                case C.U8:
                {
                    var x = first(data);
                    dst = format(x);
                }
                break;
                case C.U16:
                {
                    var x = @as<ushort>(data);
                    dst = format(x);
                }
                break;
                case C.U32:
                {
                    var x = @as<uint>(data);
                    dst = format(x);
                }
                break;
                case C.U64:
                {
                    var x = @as<ulong>(data);
                    dst = format(x);
                }
                break;

                case C.I8:
                {
                    var x = @as<sbyte>(data);
                    dst = format(x);
                }
                break;
                case C.I16:
                {
                    var x = @as<short>(data);
                    dst = format(x);
                }
                break;
                case C.I32:
                {
                    var x = @as<int>(data);
                    dst = format(x);
                }
                break;
                case C.I64:
                {
                    var x = @as<long>(data);
                    dst = format(x);
                }
                break;

                case C.X2:
                {
                    var x = first(data);
                    dst = "0x" + ((byte)(x & 0b11)).ToString("X");
                }
                break;
                case C.X3:
                {
                    var x = first(data);
                    dst = "0x" + ((byte)(x & 0b111)).ToString("X");
                }
                break;
                case C.X4:
                {
                    var x = first(data);
                    dst = "0x" + ((byte)(x & 0b1111)).ToString("X");
                }
                break;
                case C.X5:
                {
                    var x = first(data);
                    dst = "0x" + ((byte)(x & 0b11111)).ToString("X");
                }
                break;
                case C.X6:
                {
                    var x = first(data);
                    dst = "0x" + ((byte)(x & 0b111111)).ToString("X");
                }
                break;
                case C.X7:
                {
                    var x = first(data);
                    dst = "0x" + ((byte)(x & 0b1111111)).ToString("X");
                }
                break;
                case C.X8:
                {
                    Hex8 x = first(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.X16:
                {
                    Hex16 x = @as<ushort>(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.X32:
                {
                    Hex32 x = @as<uint>(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.X64:
                {
                    Hex64 x = @as<ulong>(data);
                    dst = XedRender.format(x);
                }
                break;

                case C.Disp:
                {
                    Disp64 x = @as<long>(data);
                    dst = x.Format();
                }
                break;

                case C.MemWidth:
                {
                    var x = @as<ushort>(data);
                    dst = x.ToString();
                }
                break;

                case C.Broadcast:
                {
                    var x = @as<BCastKind>(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.Chip:
                {
                    var x = @as<ChipCode>(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.Reg:
                {
                    var x = @as<XedRegId>(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.InstClass:
                {
                    var x = @as<IClass>(data);
                    dst = XedRender.format(x);
                }
                break;
                case C.VexClass:
                {
                    var x = @as<VexClass>(data);
                    dst = XedRender.format(x);
                }
                break;
            }
            return dst;
        }

        static string format(sbyte src)
            => src.ToString();

        static string format(short src)
            => src.ToString();

        static string format(int src)
            => src.ToString();

        static string format(long src)
            => src.ToString();

        static string format(byte src)
            => src.ToString();

        static string format(ushort src)
            => src.ToString();

        static string format(uint src)
            => src.ToString();

        static string format(ulong src)
            => src.ToString();

    }
}