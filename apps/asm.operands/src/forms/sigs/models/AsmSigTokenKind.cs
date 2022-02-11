//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum AsmSigTokenKind : byte
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

        KRm,

        Moffs,

        Ptr,

        Rounding,

        MemPtr,

        MemPair,

        Vsib,

        Broadcast,

        OpMask,

        RegLiteral,

        IntLiteral,

        Dependent,

        Modifier,
    }
}