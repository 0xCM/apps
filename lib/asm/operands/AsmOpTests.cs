//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [ApiHost]
    public readonly struct AsmOpTests
    {
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
    }
}