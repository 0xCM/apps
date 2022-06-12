//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm.X86
{
    /// <summary>
    /// Represent a single low-level machine instruction.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct MCInst
    {
        public uint Opcode = 0;

        /// <summary>
        /// These flags could be used to pass some info from one target subcomponent
        /// to another, for example, from disassembler to asm printer. The values of
        /// the flags have any sense on target level only (e.g. prefixes on x86).
        /// </summary>
        public uint Flags = 0;

        public MCInst()
        {

        }
    }
}