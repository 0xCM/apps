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
        [MethodImpl(Inline), Op]
        public static uint bitstring(in AsmHexCode src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(slice(src.Bytes, 0, src.Size), ref i, dst);
        }

        public static string asmbyte<T>(T src)
            where T : unmanaged, IAsmByte
                => src.Value().FormatHex(zpad:true, specifier:true, uppercase:true);

        [Op]
        public static uint bitstring(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(src, ref i, dst);
        }

        public static string directive(in AsmDirective src)
        {
            var dst = text.buffer();
            dst.AppendFormat(".{0}", src.Name);
            if(src.Op0.IsNonEmpty)
            {
                dst.AppendFormat(" {0}", src.Op0.Format());
                if(src.Op1.IsNonEmpty)
                {
                    dst.AppendFormat(", {0}", src.Op1.Format());
                    if(src.Op2.IsNonEmpty)
                        dst.AppendFormat(", {0}", src.Op2.Format());
                }
            }

            return dst.Emit();
        }

        public static string comment(in AsmComment src)
            => src.Content.IsNonEmpty ? string.Format("# {0}", src.Content) : EmptyString;

        [Op]
        public static string operand(in AsmOperand src)
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

        public static string operands(in AsmOperands src)
        {
            var dst = EmptyString;
            switch(src.OpCount)
            {
                case 0:
                break;
                case 1:
                   dst = string.Format("{0}", src.Op0);
                break;
                case 2:
                    dst = string.Format("{0}, {1}", src.Op0, src.Op1);
                break;
                case 3:
                    dst = string.Format("{0}, {1}, {2}", src.Op0, src.Op1, src.Op2);
                break;
                case 4:
                    dst = string.Format("{0}, {1}, {2}, {3}", src.Op0, src.Op1, src.Op2, src.Op3);
                break;
            }
            return dst;
        }

        public static string instruction(in AsmInstruction src)
        {
            var dst = text.buffer();
            ref readonly var ops = ref src.Operands;
            var count = ops.OpCount;
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            if(count != 0)
            {
                dst.Append(Chars.Space);
                dst.Append(src.Operands.Format());
            }
            return dst.Emit();
        }

        public static string spec(in AsmBlockSpec src)
        {
            var dst = text.buffer();

            if(src.Comment.IsNonEmpty)
                dst.AppendLine(src.Comment.Format());

            if(src.Label.IsNonEmpty)
                dst.AppendLine(src.Label);


            if(src.Content.IsNonEmpty)
            {
                var count = src.Content.Count;
                for(var i=0; i<count; i++)
                    dst.IndentLine(4, src.Content[i].Format());
            }

            return dst.Emit();
        }

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

        public static string file(in AsmFileSpec src)
        {
            var dst = text.buffer();
            var parts = src.Parts;
            var count = parts.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref parts[i];
                dst.AppendLine(part.Format());
                switch(part.PartKind)
                {
                    case AsmPartKind.Block:
                        dst.AppendLine();
                    break;
                }

            }
            return dst.Emit();
        }
    }
}