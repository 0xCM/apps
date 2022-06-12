//-----------------------------------------------------------------------------------------//
// Source : LLVM - https://github.com/llvm/llvm-project/
// License: Apache-2.0 WITH LLVM-exception
//-----------------------------------------------------------------------------------------//
namespace Z0.llvm
{
    using static CNum;

    partial struct X86Disassembler
    {
        const byte X86_MAX_OPERANDS = 6;

        public struct OperandSpecifier
        {
            public uint8_t encoding;

            public uint8_t type;

            [MethodImpl(Inline)]
            public OperandSpecifier(uint8_t e, uint8_t t)
            {
                encoding = e;
                type = t;
            }

            [MethodImpl(Inline)]
            public static implicit operator OperandSpecifier((uint8_t e, uint8_t t) src)
                => new OperandSpecifier(src.e, src.t);
        }
    }
}