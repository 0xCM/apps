//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum ErrorKind : byte
        {
            NONE, /// There was no error

            BUFFER_TOO_SHORT, /// There were not enough bytes in the given buffer

            [Symbol("error")]
            GENERAL_ERROR, /// XED could not decode the given instruction

            [Symbol("INVALID_FOR_CHIP", "The instruciton is not valid for the specified chip")]
            INVALID_FOR_CHIP,

            [Symbol("BAD_REGISTER", "XED could not decode the given instruction because an invalid register encoding was used")]
            BAD_REGISTER,

            [Symbol("BAD_LOCK_PREFIX", "A lock prefix was found where none is allowed")]
            BAD_LOCK_PREFIX,

            BAD_REP_PREFIX, /// An F2 or F3 prefix was found where none is allowed.

            BAD_LEGACY_PREFIX, /// A 66, F2 or F3 prefix was found where none is allowed.

            BAD_REX_PREFIX, /// A REX prefix was found where none is allowed.

            BAD_EVEX_UBIT, /// An illegal value for the EVEX.U bit was present in the instruction.

            BAD_MAP, /// An illegal value for the MAP field was detected in the instruction.

            BAD_EVEX_V_PRIME, /// EVEX.V'=0 was detected in a non-64b mode instruction.

            BAD_EVEX_Z_NO_MASKING, /// EVEX.Z!=0 when EVEX.aaa==0

            NO_OUTPUT_POINTER, /// The output pointer for xed_agen was zero

            NO_AGEN_CALL_BACK_REGISTERED, /// One or both of the callbacks for xed_agen were missing.

            BAD_MEMOP_INDEX, /// Memop indices must be 0 or 1.

            CALLBACK_PROBLEM, /// The register or segment callback for xed_agen experienced a problem

            GATHER_REGS, /// The index, dest and mask regs for AVX2 gathers must be different.

            INSTR_TOO_LONG, /// Full decode of instruction would exeed 15B.

            INVALID_MODE, /// The instruction was not valid for the specified mode

            BAD_EVEX_LL, /// EVEX.LL must not ==3 unless using embedded rounding

            BAD_REG_MATCH, // Source registers must not match the destination register for this instruction.
        }
    }
}