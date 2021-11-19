//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    partial struct X86Disassembler
    {
        [SymSource("llvm.mc")]
        public enum DisassemblerMode
        {
            [Symbol("","real mode")]
            MODE_16BIT,

            [Symbol("","IA-32e")]
            MODE_32BIT,

            [Symbol("","IA-32e in 64-bit mode")]
            MODE_64BIT
        };
    }
}