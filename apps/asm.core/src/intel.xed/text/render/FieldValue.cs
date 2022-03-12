//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static core;

    using R = XedRules;
    using FC = XedRules.FormatCode;

    partial class XedRender
    {
        public static string format(R.FieldValue src)
        {
            var dst = EmptyString;
            if(src.IsEmpty)
                return EmptyString;

            var data = bytes(src.Data);
            var code = fcode(src.Kind);

            switch(code)
            {
                case FC.Text:
                    dst = ((NameResolver)((int)src.Data)).Format();
                    break;
                case FC.B1:
                {
                    bit x = first(data);
                    dst = x.Format();
                }
                break;
                case FC.B2:
                {
                    uint2 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B3:
                {
                    uint3 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B4:
                {
                    uint4 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B5:
                {
                    uint5 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B6:
                {
                    uint6 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B7:
                {
                    uint7 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.B8:
                {
                    uint8b x = first(data);
                    dst = format(x);
                }
                break;

                case FC.U2:
                {
                    byte x = (byte)(first(data) & 0b11);
                    dst = format(x);
                }
                break;

                case FC.U3:
                {
                    byte x = (byte)(first(data) & 0b111);
                    dst = format(x);
                }
                break;

                case FC.U4:
                {
                    byte x = (byte)(first(data) & 0b1111);
                    dst = format(x);
                }
                break;

                case FC.U5:
                {
                    byte x = (byte)(first(data) & 0b11111);
                    dst = format(x);
                }
                break;

                case FC.U8:
                {
                    var x = first(data);
                    dst = format(x);
                }
                break;
                case FC.U16:
                {
                    var x = @as<ushort>(data);
                    dst = format(x);
                }
                break;
                case FC.U32:
                {
                    var x = @as<uint>(data);
                    dst = format(x);
                }
                break;
                case FC.U64:
                {
                    var x = @as<ulong>(data);
                    dst = format(x);
                }
                break;

                case FC.I8:
                {
                    var x = @as<sbyte>(data);
                    dst = format(x);
                }
                break;
                case FC.I16:
                {
                    var x = @as<short>(data);
                    dst = format(x);
                }
                break;
                case FC.I32:
                {
                    var x = @as<int>(data);
                    dst = format(x);
                }
                break;
                case FC.I64:
                {
                    var x = @as<long>(data);
                    dst = format(x);
                }
                break;

                case FC.X2:
                {
                    Hex2 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X3:
                {
                    Hex3 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X4:
                {
                    Hex4 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X5:
                {
                    Hex5 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X6:
                {
                    Hex6 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X7:
                {
                    Hex7 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X8:
                {
                    Hex8 x = first(data);
                    dst = format(x);
                }
                break;
                case FC.X16:
                {
                    Hex16 x = @as<ushort>(data);
                    dst = format(x);
                }
                break;
                case FC.X32:
                {
                    Hex32 x = @as<uint>(data);
                    dst = format(x);
                }
                break;
                case FC.X64:
                {
                    Hex64 x = @as<ulong>(data);
                    dst = format(x);
                }
                break;

                case FC.Disp:
                {
                    Disp64 x = @as<long>(data);
                    dst = x.Format();
                }
                break;

                case FC.Broadcast:
                {
                    var x = @as<BCastKind>(data);
                    dst = format(x);
                }
                break;
                case FC.Chip:
                {
                    var x = @as<ChipCode>(data);
                    dst = format(x);
                }
                break;
                case FC.Reg:
                {
                    var x = @as<XedRegId>(data);
                    dst = format(x);
                }
                break;
                case FC.InstClass:
                {
                    var x = @as<IClass>(data);
                    dst = format(x);
                }
                break;
                case FC.VexClass:
                {
                    var x = @as<VexClass>(data);
                    dst = format(x);
                }
                break;
                case FC.MemWidth:
                {
                    var x = @as<ushort>(data);
                    dst = x.ToString();
                }
                break;
            }
            return dst;
        }
    }
}