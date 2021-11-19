//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    partial struct X86Disassembler
    {
        [SymSource]
        public enum EncodingType : byte
        {
            ENCODING_NONE,

            [Symbol("","Register operand in ModR/M byte.")]
            ENCODING_REG,

            [Symbol("","R/M operand in ModR/M byte.")]
            ENCODING_RM,

            [Symbol("","R/M operand with CDisp scaling of 2")]
            ENCODING_RM_CD2,

            [Symbol("","R/M operand with CDisp scaling of 4")]
            ENCODING_RM_CD4,

            [Symbol("","R/M operand with CDisp scaling of 8")]
            ENCODING_RM_CD8,

            [Symbol("","R/M operand with CDisp scaling of 16")]
            ENCODING_RM_CD16,

            [Symbol("","R/M operand with CDisp scaling of 32")]
            ENCODING_RM_CD32,

            [Symbol("","R/M operand with CDisp scaling of 64")]
            ENCODING_RM_CD64,

            [Symbol("","Force SIB operand in ModR/M byte.")]
            ENCODING_SIB,

            [Symbol("","VSIB operand in ModR/M byte.")]
            ENCODING_VSIB,

            [Symbol("","VSIB operand with CDisp scaling of 2")]
            ENCODING_VSIB_CD2,

            [Symbol("","VSIB operand with CDisp scaling of 4")]
            ENCODING_VSIB_CD4,

            [Symbol("","VSIB operand with CDisp scaling of 8")]
            ENCODING_VSIB_CD8,

            [Symbol("","VSIB operand with CDisp scaling of 16")]
            ENCODING_VSIB_CD16,

            [Symbol("","VSIB operand with CDisp scaling of 32")]
            ENCODING_VSIB_CD32,

            [Symbol("","VSIB operand with CDisp scaling of 64")]
            ENCODING_VSIB_CD64,

            [Symbol("","Register operand in VEX.vvvv byte")]
            ENCODING_VVVV,

            [Symbol("","Register operand in EVEX.aaa byte.")]
            ENCODING_WRITEMASK,

            [Symbol("","1-byte immediate")]
            ENCODING_IB,

            [Symbol("","2-byte")]
            ENCODING_IW,

            [Symbol("","4-byte")]
            ENCODING_ID,

            [Symbol("","8-byte")]
            ENCODING_IO,

            [Symbol("","(AL..DIL, R8B..R15B) Register code added to the opcode byte")]
            ENCODING_RB,

            [Symbol("","(AX..DI, R8W..R15W)")]
            ENCODING_RW,

            [Symbol("","(EAX..EDI, R8D..R15D)")]
            ENCODING_RD,

            [Symbol("","(RAX..RDI, R8..R15)")]
            ENCODING_RO,

            [Symbol("","Position on floating-point stack in ModR/M byte")]
            ENCODING_FP,

            [Symbol("","Immediate of operand size")]
            ENCODING_Iv,

            [Symbol("","Immediate of address size")]
            ENCODING_Ia,

            [Symbol("","Immediate for static rounding control")]
            ENCODING_IRC,

            [Symbol("","Register code of operand size added to the opcode byte")]
            ENCODING_Rv,

            [Symbol("","Condition code encoded in opcode")]
            ENCODING_CC,

            [Symbol("", "Duplicate of another operand; ID is encoded in type ")]
            ENCODING_DUP,

            [Symbol("", "Source index; encoded in OpSize/Adsize prefix")]
            ENCODING_SI,

            [Symbol("", "Destination index; encoded in prefixes")]
            ENCODING_DI,
        }
    }
}