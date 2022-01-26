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
        internal static string format(in AsmOperand src)
        {
            if(src.IsReg)
                return src.Reg.Format();
            else if(src.IsMem)
                return src.Mem.Format();
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
                return src.RegMask.Format();
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

        internal static string format(in RegRange src)
            => string.Format("{0}[{1}..{2}]", src.Class, src.MinIndex, src.MaxIndex);
   }
}