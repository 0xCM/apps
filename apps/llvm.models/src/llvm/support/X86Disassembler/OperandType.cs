//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    partial struct X86Disassembler
    {
        [SymSource("llvm.mc")]
        public enum OperandType : byte
        {
            [Symbol("", "")]
            TYPE_NONE,

            [Symbol("", "immediate address")]
            TYPE_REL,

            [Symbol("", "1-byte register operand")]
            TYPE_R8,

            [Symbol("", "2-byte")]
            TYPE_R16,

            [Symbol("", "4-byte")]
            TYPE_R32,

            [Symbol("", "8-byte")]
            TYPE_R64,

            [Symbol("", "immediate operand")]
            TYPE_IMM,

            [Symbol("", "1-byte unsigned immediate operand")]
            TYPE_UIMM8,

            [Symbol("", "Memory operand")]
            TYPE_M,

            [Symbol("", "Memory operand force sib encoding")]
            TYPE_MSIB,

            [Symbol("","Memory operand using XMM index")]
            TYPE_MVSIBX,

            [Symbol("", "Memory operand using YMM index")]
            TYPE_MVSIBY,

            [Symbol("", "Memory operand using ZMM index")]
            TYPE_MVSIBZ,

            [Symbol("", "memory at source index")]
            TYPE_SRCIDX,

            [Symbol("", "memory at destination index")]
            TYPE_DSTIDX,

            [Symbol("", "memory offset (relative to segment base)")]
            TYPE_MOFFS,

            [Symbol("", "Position on the floating-point stack")]
            TYPE_ST,

            [Symbol("", "8-byte MMX register")]
            TYPE_MM64,

            [Symbol("", "16-byte")]
            TYPE_XMM,

            [Symbol("", "32-byte")]
            TYPE_YMM,

            [Symbol("", "64-byte")]
            TYPE_ZMM,

            [Symbol("", "mask register")]
            TYPE_VK,

            [Symbol("", "mask register pair")]
            TYPE_VK_PAIR,

            [Symbol("", "tile")]
            TYPE_TMM,

            [Symbol("", "Segment register operand")]
            TYPE_SEGMENTREG,

            [Symbol("", "Debug register operand")]
            TYPE_DEBUGREG,

            [Symbol("", "Control register operand")]
            TYPE_CONTROLREG,

            [Symbol("", "MPX bounds register")]
            TYPE_BNDR,

            [Symbol("", "Register operand of operand size")]
            TYPE_Rv,

            [Symbol("", "Immediate address of operand size")]
            TYPE_RELv,

            [Symbol("", "Duplicate of operand 0")]
            TYPE_DUP0,

            [Symbol("", "operand 1")]
            TYPE_DUP1,

            [Symbol("", "operand 2")]
            TYPE_DUP2,

            [Symbol("", "operand 3")]
            TYPE_DUP3,

            [Symbol("", "operand 4")]
            TYPE_DUP4,
        }
    }
}