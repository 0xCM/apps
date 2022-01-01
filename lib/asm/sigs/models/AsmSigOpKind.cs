//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public enum AsmSigOpKind : byte
    {
        None = 0,

        GpReg,

        VecReg,

        MaskReg,

        FpuReg,

        SysReg,

        [Symbol("mm")]
        MmxReg,

        Imm,

        Mem,

        FpuMem,

        GpRm,

        VecRm,

        Moffs,

        Rel,

        SrcOp,

        Ptr,

        Rounding,

        FarPtr,

        MemPair,

        Vsib,

        Broadcast,

        [Symbol("xmm")]
        XmmReg,

        [Symbol("ymm")]
        YmmReg,

        [Symbol("zmm")]
        ZmmReg,

        [Symbol("rK")]
        OpMask
    }
}