//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum AsmSigOpKind : byte
    {
        None = 0,

        Rel,

        SysReg,

        GpReg,

        VecReg,

        MaskReg,

        FpuReg,

        MmxReg,

        Imm,

        Mem,

        FpuMem,

        GpRm,

        VecRm,

        Moffs,

        SrcOp,

        Ptr,

        Rounding,

        FarPtr,

        MemPair,

        Vsib,

        Broadcast,

        XmmReg,

        YmmReg,

        ZmmReg,

        OpMask,

        RegLiteral,
    }
}