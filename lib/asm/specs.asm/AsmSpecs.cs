//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct AsmSpecs
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static AsmSpec define(in AsmMnemonic mnemonic, in AsmOcSpec opcode, params AsmOperand[] ops)
        {
            var count = ops.Length;
            switch(count)
            {
                case 0:
                    return define(mnemonic, opcode, out _);
                case 1:
                    return define(mnemonic, opcode, skip(ops,0), out _);
                case 2:
                    return define(mnemonic, opcode, skip(ops,0), skip(ops,1), out _);
                case 3:
                    return define(mnemonic, opcode, skip(ops,0),skip(ops,1), skip(ops,2), out _);
                case 4:
                    return define(mnemonic, opcode, skip(ops,0),skip(ops,1), skip(ops,2), skip(ops,3), out _);
            }
            return AsmSpec.Empty;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOcSpec opcode, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands = AsmOperands.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOcSpec opcode, in AsmOperand op0, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 1;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = AsmOperand.Empty;
            dst.Operands.Op2 = AsmOperand.Empty;
            dst.Operands.Op3 = AsmOperand.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOcSpec opcode, in AsmOperand op0, in AsmOperand op1, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 2;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = op1;
            dst.Operands.Op2 = AsmOperand.Empty;
            dst.Operands.Op3 = AsmOperand.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOcSpec opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 3;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = op1;
            dst.Operands.Op2 = op2;
            dst.Operands.Op3 = AsmOperand.Empty;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref AsmSpec define(in AsmMnemonic mnemonic, in AsmOcSpec opcode, in AsmOperand op0, in AsmOperand op1, in AsmOperand op2, in AsmOperand op3, out AsmSpec dst)
        {
            dst.Mnemonic = mnemonic;
            dst.OpCode = opcode;
            dst.Operands.OpCount = 4;
            dst.Operands.Op0 = op0;
            dst.Operands.Op1 = op1;
            dst.Operands.Op2 = op2;
            dst.Operands.Op3 = op3;
            return ref dst;
        }

        internal static string format(in AsmSpec src)
        {
            var dst = text.buffer();
            ref readonly var ops = ref src.Operands;
            var count = ops.OpCount;
            dst.Append(src.Mnemonic.Format(MnemonicCase.Lowercase));
            switch(count)
            {
                case 0:
                break;
                case 1:
                    dst.AppendFormat(" {0}", ops.Op0);
                break;
                case 2:
                    dst.AppendFormat(" {0}, {1}", ops.Op0, ops.Op1);
                break;
                case 3:
                    dst.AppendFormat(" {0}, {1}, {2}", ops.Op0, ops.Op1, ops.Op2);
                break;
                case 4:
                    dst.AppendFormat(" {0}, {1}, {2}, {3}", ops.Op0, ops.Op1, ops.Op2, ops.Op3);
                break;
            }
            return dst.Emit();
        }

        [Op]
        internal static string format(in AsmOperand src)
        {
            if(src.IsReg)
                return format(src.Reg);
            else if(src.IsMem)
                return format(src.Mem);
            else if(src.IsImm)
            {
                return src.Size.Code switch
                {
                    NativeSizeCode.W8 => format(src.Imm8),
                    NativeSizeCode.W16 => format(src.Imm16),
                    NativeSizeCode.W32 => format(src.Imm32),
                    NativeSizeCode.W64 => format(src.Imm64),
                    _ => "<unsized>",

                };
            }
            else if(src.IsRegMask)
                return format(src.RegMask);
            else if(src.IsDisp)
                return src.Disp.Format();
            else
                return EmptyString;
        }

        [MethodImpl(Inline), Op]
        internal static bool IsMem(AsmOpKind kind)
            => (kind & AsmOpKind.Mem) != 0;

        [MethodImpl(Inline), Op]
        internal static bool IsReg(AsmOpKind kind)
            => (kind & AsmOpKind.Reg) != 0;

        [MethodImpl(Inline), Op]
        internal static bool IsImm(AsmOpKind kind)
            => (kind & AsmOpKind.Imm) != 0;

        [MethodImpl(Inline), Op]
        internal static bool IsDisp(AsmOpKind kind)
            => (kind & AsmOpKind.Disp) != 0;

        [MethodImpl(Inline), Op]
        internal static bool IsRegMask(AsmOpKind kind)
            => (kind & AsmOpKind.RegMask) != 0;

        internal static string format(in imm8 src)
            => HexFormatter.format(w8, src.Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        internal static string format(in imm16 src)
            => HexFormatter.format(w16, src.Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        internal static string format(in imm32 src)
            => HexFormatter.format(w32, src.Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        internal static string format(in imm64 src)
            => HexFormatter.format(w64, src.Value, HexPadStyle.Unpadded, prespec:true, @case:UpperCase);

        [Op]
        internal static string format(in Imm src)
            => src.ImmKind switch
            {
                ImmKind.Imm8 => HexFormatter.format(w8, src.Imm8, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm8i => HexFormatter.format(w8i, src.Imm8i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16 => HexFormatter.format(w16, src.Imm16, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm16i => HexFormatter.format(w16i, src.Imm16i, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32 => HexFormatter.format(w32, src.Imm32, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm32i => HexFormatter.format(w32, src.Imm32, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64 => HexFormatter.format(w64, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                ImmKind.Imm64i => HexFormatter.format(w64, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase),
                _ => string.Format("{0}:<1>", HexFormatter.format(w64, src.Imm64, HexPadStyle.Unpadded, prespec:true, @case:UpperCase), src.ImmKind),
            };

        internal static string format(in RegRange src)
            => string.Format("{0}[{1}..{2}]", src.Class, src.MinIndex, src.MaxIndex);

        [Op]
        public static string format(in RegMask src)
        {
            var dst = EmptyString;
            if(src.Kind == RegMaskKind.Merge)
                dst = string.Format("{0} {{1}}", src.Target, AsmRegs.rK(src.Mask));
            else if(src.Kind == RegMaskKind.Zero)
                dst = string.Format("{0} {{{1}}{{2}}", src.Target, AsmRegs.rK(src.Mask), Chars.z);
            return dst;
        }

        [Op]
        internal static string format(in AsmAddress src)
        {
            var dst = CharBlock32.Null.Data;
            var i=0u;
            var count = render(src, ref i, dst);
            return text.format(dst, count);
        }

        [Op]
        internal static string format(in MemOp src)
            => format(src.Address);

        [Op]
        internal static string format(in RegOp src)
            => src.Name.Format().Trim();

        [Op]
        internal static uint render(in AsmAddress src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var @base = src.Base.Format();
            var index = src.Index.Format();
            text.copy(@base, ref i, dst);
            var scale = src.Scale.Format();
            if(src.Scale.IsNonZero)
            {
                seek(dst,i++) = Chars.Plus;
                text.copy(index, ref i, dst);
                if(src.Scale.IsNonUnital)
                {
                    seek(dst,i++) = Chars.Star;
                    text.copy(scale,ref i, dst);
                }
            }

            if(src.Disp.Value != 0)
            {
                seek(dst,i++) = Chars.Plus;
                text.copy(src.Disp.Value.ToString("x") + "h", ref i, dst);
            }

            return i - i0;
        }
   }
}