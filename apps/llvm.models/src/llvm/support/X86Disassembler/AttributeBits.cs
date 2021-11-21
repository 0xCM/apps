//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    /// <summary>
    /// From https://github.com/llvm/llvm-project/blob/a8ad9170543906fc58336ab736a109fb42082fbf/llvm/include/llvm/Support/X86DisassemblerDecoderCommon.h
    /// </summary>
    partial struct X86Disassembler
    {
        /// <summary>
        /// Attributes of an instruction that must be known before the opcode can be
        /// processed correctly.  Most of these indicate the presence of particular
        /// prefixes, but ATTR_64BIT is simply an attribute of the decoding context.
        /// </summary>
        [SymSource("llvm.mc")]
        public enum AttributeBits : ushort
        {
            ATTR_NONE = 0x00,

            ATTR_64BIT = 0x1 << 0,

            ATTR_XS = 0x1 << 1,

            ATTR_XD = 0x1 << 2,

            ATTR_REXW = 0x1 << 3,

            ATTR_OPSIZE = 0x1 << 4,

            ATTR_ADSIZE = 0x1 << 5,

            ATTR_VEX = 0x1 << 6,

            ATTR_VEXL = 0x1 << 7,

            ATTR_EVEX = 0x1 << 8,

            ATTR_EVEXL2 = 0x1 << 9,

            ATTR_EVEXK = 0x1 << 10,

            ATTR_EVEXKZ = 0x1 << 11,

            ATTR_EVEXB = 0x1 << 12,

            ATTR_max = 0x1 << 13,
        }
    }
}