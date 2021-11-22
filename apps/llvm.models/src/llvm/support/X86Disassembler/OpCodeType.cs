//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    partial struct X86Disassembler
    {
        /// <summary>
        /// From https://github.com/llvm/llvm-project/blob/a8ad9170543906fc58336ab736a109fb42082fbf/llvm/include/llvm/Support/X86DisassemblerDecoderCommon.h
        /// </summary>
        [SymSource("llvm.mc")]
        public enum OpCodeType : byte
        {
            ONEBYTE = 0,

            TWOBYTE = 1,

            THREEBYTE_38 = 2,

            THREEBYTE_3A = 3,

            XOP8_MAP = 4,

            XOP9_MAP = 5,

            XOPA_MAP = 6,

            THREEDNOW_MAP = 7
        }
    }
}