//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static RegOp reg(NativeSizeCode width, RegClassCode @class, RegIndexCode r)
            => AsmRegs.reg(width, @class,r);

        [MethodImpl(Inline), Op]
        public static RegOp reg(RegKind kind)
            => AsmRegs.reg(kind);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => AsmRegs.reg(src);

        [MethodImpl(Inline), Op]
        public static RegMask regmask(RegOp target, RegIndex mask, RegMaskKind kind)
            => new RegMask(target,mask,kind);
    }
}