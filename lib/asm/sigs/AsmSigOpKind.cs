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

        FpuInt,

        FpuMem,

        GpRm,

        VecRm,

        Moffs,

        Ptr,

        Rounding,

        MemPtr,

        MemPair,

        Vsib,

        Broadcast,

        OpMask,

        RegLiteral,

        Dependent,
    }
}