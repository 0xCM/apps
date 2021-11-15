//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Classifies asm signature operands
    /// </summary>
    public enum AsmSigOpKind : byte
    {
        /// <summary>
        /// A specific 8-bit gp register
        /// </summary>
        Gp8Reg,

        /// <summary>
        /// A range of 8-bit gp registers
        /// </summary>
        Gp8RegRange,

        /// <summary>
        /// A specific 16-bit gp register
        /// </summary>
        Gp16Reg,

        /// <summary>
        /// A range of 16-bit gp registers
        /// </summary>
        Gp16RegRange,

        /// <summary>
        /// A specific 32-bit gp register
        /// </summary>
        Gp32Reg,

        /// <summary>
        /// A range of 32-bit gp registers
        /// </summary>
        Gp32RegRange,

        /// <summary>
        /// A specific 64-bit gp register
        /// </summary>
        Gp64Reg,

        /// <summary>
        /// A range of 64-bit gp registers
        /// </summary>
        Gp64RegRange,

        /// <summary>
        /// A range MMX registers
        /// </summary>
        MmxRegRange,

        /// <summary>
        /// A range FPU registers
        /// </summary>
        FpuRegRange,

        /// <summary>
        /// A range of 128-bit vector registers
        /// </summary>
        XmmRegRange,

        /// <summary>
        /// A range of 256-bit vector registers
        /// </summary>
        YmmRegRange,

        /// <summary>
        /// A range of 512-bit vector registers
        /// </summary>
        ZmmRegRange,

        /// <summary>
        /// A 64-bit mask register
        /// </summary>
        MaskRegRange,

        /// <summary>
        /// A range of control registers
        /// </summary>
        CrRegRange,

        /// <summary>
        /// A range of debug registers registers
        /// </summary>
        DbRegRange,

        /// <summary>
        /// A specific segment register
        /// </summary>
        SegReg,

        /// <summary>
        /// A range of segment registers
        /// </summary>
        SegRegRange,

        /// <summary>
        /// An 8-bit immediate value
        /// </summary>
        Imm8,

        /// <summary>
        /// A 16-bit immediate value
        /// </summary>
        Imm16,

        /// <summary>
        /// A 32-bit immediate value
        /// </summary>
        Imm32,

        /// <summary>
        /// A 64-bit immediate value
        /// </summary>
        Imm64,

        /// <summary>
        /// An 8-bit memory reference
        /// </summary>
        Mem8,

        /// <summary>
        /// A 16-bit memory reference
        /// </summary>
        Mem16,

        /// <summary>
        /// A 32-bit memory reference
        /// </summary>
        Mem32,

        /// <summary>
        /// A 64-bit memory reference
        /// </summary>
        Mem64,

        /// <summary>
        /// A 128-bit memory reference
        /// </summary>
        Mem128,

        /// <summary>
        /// A 256-bit memory reference
        /// </summary>
        Mem256,

        /// <summary>
        /// A 512-bit memory reference
        /// </summary>
        Mem512,

        /// <summary>
        /// An 8-bit RIP-relative address
        /// </summary>
        Rel8,

        /// <summary>
        /// A 16-bit RIP-relative address
        /// </summary>
        Rel16,

        /// <summary>
        /// A 32-bit RIP-relative address
        /// </summary>
        Rel32,

        /// <summary>
        /// A segbase-relative 8-bit address
        /// </summary>
        Moffs8,

        /// <summary>
        /// A segbase-relative 16-bit address
        /// </summary>
        Moffs16,

        /// <summary>
        /// A segbase-relative 32-bit address
        /// </summary>
        Moffs32,

        /// <summary>
        /// A segbase-relative 64-bit address
        /// </summary>
        Moffs64
    }
}