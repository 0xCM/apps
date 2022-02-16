//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public readonly struct AsmRender
    {
        [Op]
        public static string format(in AsmOperand src)
        {
            switch(src.OpClass)
            {
                case AsmOpClass.Mem:
                    return mem(src.Mem);
                case AsmOpClass.Reg:
                    return reg(src.Reg);
                case AsmOpClass.Imm:
                    return imm(src.Imm);
                case AsmOpClass.Disp:
                    return disp(src.Disp);
                case AsmOpClass.RegMask:
                    return regmask(src.RegMask);
                default:
                    return EmptyString;

            }
        }
        //     switch(src.OpKind)
        //     {
        //         case AsmOpKind.Mem8:
        //         case AsmOpKind.Mem16:
        //         case AsmOpKind.Mem32:
        //         case AsmOpKind.Mem64:
        //         case AsmOpKind.Mem128:
        //         case AsmOpKind.Mem256:
        //         case AsmOpKind.Mem512:
        //             return mem(src.Mem);
        //         case AsmOpKind.Imm8:
        //             return src.Imm8.Format();
        //         case AsmOpKind.Imm16:
        //             return src.Imm16.Format();
        //         case AsmOpKind.Imm32:
        //             return src.Imm32.Format();
        //         case AsmOpKind.Imm64:
        //             return src.Imm64.Format();
        //         case AsmOpKind.RegMask8:
        //         case AsmOpKind.RegMask16:
        //         case AsmOpKind.RegMask32:
        //         case AsmOpKind.RegMask64:
        //         case AsmOpKind.RegMask128:
        //         case AsmOpKind.RegMask256:
        //         case AsmOpKind.RegMask512:
        //             return src.RegMask.Format();
        //         case AsmOpKind.Disp8:
        //         case AsmOpKind.Disp16:
        //         case AsmOpKind.Disp32:
        //         case AsmOpKind.Disp64:
        //             return disp(src.Disp);

        //     }
        //     if(src.IsReg)
        //         return src.Reg.Format();
        //     else
        //         return EmptyString;
        // }


        public static string reg(RegOp src)
            => src.Name.Format().Trim();

        [Op]
        public static string regmask(in RegMask src)
        {
            var dst = EmptyString;
            if(src.MaskKind == RegMaskKind.k1)
                dst = string.Format("{0} {{1}}", src.Target, AsmRegs.rK(src.Mask));
            else if(src.MaskKind == RegMaskKind.k1z)
                dst = string.Format("{0} {{{1}}{{2}}", src.Target, AsmRegs.rK(src.Mask), Chars.z);
            return dst;
        }

        [Op]
        public static string imm(in Imm src)
            => src.ImmKind switch
            {
                ImmKind.Imm8 => HexFormatter.format(src.Size, src.Imm8, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm8i => HexFormatter.format(src.Size, src.Imm8i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16 => HexFormatter.format(src.Size, src.Imm16, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16i => HexFormatter.format(src.Size, src.Imm16i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32 => HexFormatter.format(src.Size, src.Imm32, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32i => HexFormatter.format(src.Size, src.Imm32, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64 => HexFormatter.format(src.Size, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64i => HexFormatter.format(src.Size, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                _ => string.Format("{0}:<1>", HexFormatter.format(src.Size, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase), src.ImmKind),
            };

        public static string disp<T>(T src, bool @signop = false)
            where T : IDisplacement
        {
            var dst = text.buffer();
            var value = src.Value;
            if(src.Negative)
            {
                if(@signop)
                {
                    dst.Append(Chars.Dash);
                    dst.Append(Chars.Space);
                }
                else
                    dst.Append(Chars.Dash);

                switch(src.Size.Code)
                {
                    case NativeSizeCode.W8:
                        dst.Append(((byte)((~((byte)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W16:
                        dst.Append(((ushort)((~((ushort)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W32:
                        dst.Append(((uint)((~((uint)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W64:
                        dst.Append(((ulong)((~((ulong)value) + 1))).FormatHex(zpad:false, uppercase:true));
                    break;
                    default:
                        dst.Append(string.Format("error<{0}>", src.Size.Code));
                    break;
                }
            }
            else
            {
                if(@signop)
                {
                    dst.Append(Chars.Plus);
                    dst.Append(Chars.Space);
                }

                switch(src.Size.Code)
                {
                    case NativeSizeCode.W8:
                        dst.Append(((byte)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W16:
                        dst.Append(((ushort)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W32:
                        dst.Append(((uint)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    case NativeSizeCode.W64:
                        dst.Append(((long)value).FormatHex(zpad:false, uppercase:true));
                    break;
                    default:
                        dst.Append(string.Format("error<{0}>", src.Size.Code));
                    break;
                }
            }
            return dst.Emit();
        }

        public static string mem<T>(T src)
            where T : unmanaged, IMemOp
        {
            var dst = text.buffer();
            var ptrKind = (AsmPointerKind)(byte)src.TargetSize;
            var ptr = string.Format("{0} ptr [", expr(ptrKind));
            dst.Append(ptr);
            dst.Append(address(src.Address));
            dst.Append(Chars.RBracket);
            return dst.Emit();
        }

        public static string expr<T>(T src)
            where T : unmanaged, Enum
                => Symbols.index<T>()[src].Expr.Format();

        [Op]
        internal static string address(in AsmAddress src)
        {
            Span<char> dst = stackalloc char[64];
            var i=0u;
            var count = address(src, ref i, dst);
            return text.format(dst, count);
        }

        [Op]
        internal static uint address(in AsmAddress src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var @base = src.Base.Format();
            var index = src.Index.Format();
            text.copy(@base, ref i, dst);
            var scale = src.Scale.Format();
            if(src.Scale.IsNonZero)
            {
                seek(dst,i++) = Chars.Space;
                seek(dst,i++) = Chars.Plus;
                seek(dst,i++) = Chars.Space;
                if(src.Scale.IsNonUnital)
                {
                    text.copy(scale,ref i, dst);
                    seek(dst,i++) = Chars.Star;
                }
                text.copy(index, ref i, dst);
            }

            if(src.Disp.Value != 0)
            {
                seek(dst,i++) = Chars.Space;
                text.copy(disp(src.Disp,true), ref i, dst);
            }

            return i - i0;
        }
    }
}