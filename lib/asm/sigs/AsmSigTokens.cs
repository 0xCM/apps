//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigModels
    {
        const string tokens = "asm.sigs";

        [SymSource(tokens)]
        public enum SysRegToken : byte
        {
            [Symbol("bnd", "A 128-bit bounds register. BND0 through BND3")]
            bnd,

            [Symbol("Sreg", "A segment register. The segment register bit assignments are ES = 0, CS = 1, SS = 2, DS = 3, FS = 4, and GS = 5")]
            Sreg,

            [Symbol("cr")]
            cr,

            [Symbol("db")]
            db,
        }

        [SymSource(tokens)]
        public enum RegLiteralToken : byte
        {
            [Symbol("AL")]
            AL,

            [Symbol("AX")]
            AX,

            [Symbol("EAX")]
            EAX,

            [Symbol("RAX")]
            RAX
        }

        [SymSource(tokens)]
        public enum GpRegToken : byte
        {
            [Symbol("reg", "A gp register used for instructions when the width of the register does not matter to the semantics of the operation of the instruction. The register can be r16, r32, or r64.")]
            reg,

            [Symbol("al", "The al register")]
            al,

            [Symbol("ax", "The ax register")]
            ax,

            [Symbol("eax", "The eax register")]
            eax,

            [Symbol("rax", "The rax register")]
            rax,

            /// <summary>
            ///  One of {al, cl, dl, bl, ah, ch, dh, bh, bpl, spl, dil, sil} or {r8b, r9b, r10b, r11b, r12b, r13b, r14b, r15b} when using REX.R and 64-bit mode.
            /// </summary>
            [Symbol("r8", "An 8-bit gp register")]
            r8,

            /// <summary>
            ///  One of {al, cx, cx, bx,sp, bp, si, di} or {r8w, r9w, r10w, r11w, r12w, r13w, r14w, r15w} when using REX.R and 64-bit mode.
            /// </summary>
            [Symbol("r16", "A 16-bit gp register")]
            r16,

            /// <summary>
            ///  One of {eax, ecx, edx, ebx, esp, ebp, esi edi} or {r8d, r9d, r10d, r11d, r12d, r13d, r14d, r15d} when using REX.R and 64-bit mode.d
            /// </summary>
            [Symbol("r32", "A 32-bit gp register")]
            r32,

            /// <summary>
            ///  One of {rax, rcx, rdx, rbx, rsp, rbp, rsi rdi} or {r8w, r9w, r10w, r11w, r12w, r13w, r14w, r15w} when using REX.R and 64-bit mode.
            /// </summary>
            [Symbol("r64", "A 64-bit gp register")]
            r64,
        }

        [SymSource(tokens)]
        public enum MmxRegToken : byte
        {
            [Symbol("mm", "An MMX register", "MM0|MM1|MM2|MM3|MM4|MM5|MM6|MM7")]
            mm,

            [Symbol("mm/m32", "The low-order bits of an mmx register or a 32-bit memory operand; The contents of memory are found at the address provided by the effective address computation")]
            mm32,

            [Symbol("mm/m64", "An mmx register or a 64-bit memory operand; The contents of memory are found at the address provided by the effective address computation")]
            mm64,
        }

        [SymSource(tokens)]
        public enum MaskRegToken : byte
        {
            [Symbol("rK", "A mask register used as a regular operand (either destination or source)")]
            rK,
        }

        [SymSource(tokens)]
        public enum VRegToken : byte
        {
            [Symbol("xmm", "An XMM register")]
            xmm,

            [Symbol("ymm", "A YMM register")]
            ymm,

            [Symbol("zmm", "A zmm register")]
            zmm,
        }

        [SymSource(tokens)]
        public enum FpuRegToken : byte
        {
            [Symbol("ST(0)", "The top element of the FPU register stack")]
            ST0,

            [Symbol("ST(1)")]
            ST1,

            [Symbol("ST(2)")]
            ST2,

            [Symbol("ST(3)")]
            ST3,

            [Symbol("ST(4)")]
            ST4,

            [Symbol("ST(5)")]
            ST5,

            [Symbol("ST(6)")]
            ST6,

            [Symbol("ST(7)")]
            ST7,
        }

        [SymSource(tokens)]
        public enum FpuMemToken : byte
        {
            [Symbol("m16int", "Indicates a 16-bit integer memory operand in the context of an FPU integer instruction")]
            m16int,

            [Symbol("m32int", "Indicates a 32-bit integer memory operand in the context of an FPU integer instruction")]
            m32int,

            [Symbol("m64int", "Indicates a 64-bit integer memory operand in the context of an FPU integer instruction")]
            m64int,

            [Symbol("m32fp", "A single-precision floating-point operand in memory")]
            m32fp,

            [Symbol("m64fp", "A double-precision floating-point operand in memory")]
            m64fp,

            [Symbol("m80fp", "A double extended-precision floating-point operand in memory")]
            m80fp,
        }

        [SymSource(tokens)]
        public enum ImmToken : byte
        {
            [Symbol("imm8", "An immediate 8-bit value in the inclusive range [–128, 127]. For instructions in which imm8 is combined with a word or doubleword operand, the immediate value is sign-extended to form a word or doubleword. The upper byte of the word is filled with the topmost bit of the immediate value")]
            imm8 = NativeSizeCode.W8,

            [Symbol("imm16", "An immediate value for a 16-bit operand in the inclusive range [-32_768, 32_767]")]
            imm16 = NativeSizeCode.W16,

            [Symbol("imm32", "An immediate value for a 16-bit operand in the inclusive range [-32_768, 32_767]")]
            imm32 = NativeSizeCode.W32,

            [Symbol("imm64", "An immediate value for a 64-bit operand in the inclusive range [-9_223_372_036_854_775_808, 9_223_372_036_854_775_807]")]
            imm64 = NativeSizeCode.W64,
        }

        [SymSource(tokens)]
        public enum MemToken : byte
        {
            [Symbol("m8", "A byte operand in memory ( usually expressed as a variable or array name) but pointed to by the DS:(E)SI or ES:(E)DI registers. In 64-bit mode, it is pointed to by the RSI or RDI registers")]
            m8 = NativeSizeCode.W8,

            [Symbol("m16", "A word operand in memory (usually expressed as a variable or array name) but pointed to by the DS:(E)SI or ES:(E)DI registers. This nomenclature is used only with the string instructions")]
            m16 = NativeSizeCode.W16,

            [Symbol("m32", "A doubleword operand in memory (usually expressed as a variable or array name) but pointed to by the DS:(E)SI or ES:(E)DI registers. This nomenclature is used only with the string instructions")]
            m32 = NativeSizeCode.W32,

            [Symbol("m64", "A 64-bit operand in memory")]
            m64 = NativeSizeCode.W64,

            [Symbol("m128", "A 128-bit memory operand")]
            m128 = NativeSizeCode.W128,

            [Symbol("m256", "A 256-bit memory operand")]
            m256 = NativeSizeCode.W256,

            [Symbol("m512", "A 512-bit memory operand")]
            m512 = NativeSizeCode.W512,

        }

        [SymSource(tokens)]
        public enum DependentToken : byte
        {
            [Symbol("m", "A memory operand of width 16, 32 or 64 bits")]
            m,

            [Symbol("mem", "A memory operand of width 16, 32 or 64 bits")]
            mem,

            [Symbol("/r", "Indicates that the ModR/M byte of the instruction contains a register operand and an r/m operand")]
            r,

            [Symbol("mV", "A vector memory operand; the operand size is dependent on the instruction")]
            mV,
        }

        [SymSource(tokens)]
        public enum GpRmToken : byte
        {
            [Symbol("r/m8", "A byte operand that is either the contents of a byte general-purpose register: {AL CL DL BL AH CH DH BH BPL SPL DIL SIL}; or a byte from memory. Byte registers R8L - R15L are available using REX.R in 64-bit mode")]
            rm8 = NativeSizeCode.W8,

            [Symbol("r/m16", "A word general-purpose register or memory operand used for instructions whose operand-size attribute is 16 bits. The word general-purpose registers are: AX, CX, DX, BX, SP, BP, SI, DI. The contents of memory are found at the address provided by the effective address computation. Word registers R8W - R15W are available using REX.R in 64-bit mode")]
            rm16 = NativeSizeCode.W16,

            [Symbol("r/m32", "A doubleword general-purpose register or memory operand used for instructions whose operand size attribute is 32 bits. The doubleword general-purpose registers are: EAX, ECX, EDX, EBX, ESP, EBP, ESI, EDI. The contents of memory are found at the address provided by the effective address computation. Doubleword registers R8D - R15D are available when using REX.R in 64-bit mode")]
            rm32 = NativeSizeCode.W32,

            [Symbol("r/m64", "A quadword general-purpose register or memory operand used for instructions whose operand-size attribute is 64 bits when using REX.W. Quadword general-purpose registers are: RAX, RBX, RCX, RDX, RDI, RSI, RBP, RSP, R8–R15; these are available only in 64-bit mode. The contents of memory are found at the address provided by the effective address computation")]
            rm64 = NativeSizeCode.W64,
        }

        [SymSource(tokens)]
        public enum VecRmToken : byte
        {
            [Symbol("xmm/m32", "An XMM register or a 32-bit memory operand. The 128-bit XMM registers are XMM0 through XMM7; XMM8 through XMM15 are available using REX.R in 64-bit mode. The contents of memory are found at the address provided by the effective address computation")]
            xmm32 = NativeSizeCode.W32,

            [Symbol("xmm/m64", "An XMM register or a 64-bit memory operand. The 128-bit SIMD floating-point registers are XMM0 through XMM7; XMM8 through XMM15 are available using REX.R in 64-bit mode. The contents of memory are found at the address provided by the effective address computation")]
            xmm64 = NativeSizeCode.W64,

            [Symbol("xmm/m128", "An XMM register or a 128-bit memory operand")]
            xmm128 = NativeSizeCode.W128,

            [Symbol("xmm/m128", "An XMM register or a 128-bit memory operand")]
            ymm256 = NativeSizeCode.W256,

            [Symbol("zmm/m512", "A ZMM register or a 512-bit memory operand")]
            zmm512 = NativeSizeCode.W512,
        }

        [SymSource(tokens)]
        public enum VsibToken : byte
        {
            [Symbol("vm32x", "A vector array of memory operands specified using VSIB memory addressing. The array of memory addresses are specified using a common base register, a constant scale factor, and a vector index register with individual elements of 32-bit index value in an XMM register")]
            vm32x,

            [Symbol("vm32y", "A vector array of memory operands specified using VSIB memory addressing. The array of memory addresses are specified using a common base register, a constant scale factor, and a vector index register with individual elements of 32-bit index value in a YMM register")]
            vm32y,

            [Symbol("vm32z", "A vector array of memory operands specified using VSIB memory addressing. The array of memory addresses are specified using a common base register, a constant scale factor, and a vector index register with individual elements of 32-bit index value in a ZMM register (vm32z).")]
            vm32z,

            [Symbol("vm64x", "A vector array of memory operands specified using VSIB memory addressing. The array of memory addresses are specified using a common base register, a constant scale factor, and a vector index register with individual elements of 64-bit index value in an XMM register")]
            vm64x,

            [Symbol("vm64y", "A vector array of memory operands specified using VSIB memory addressing. The array of memory addresses are specified using a common base register, a constant scale factor, and a vector index register with individual elements of 64-bit index value in a YMM register")]
            vm64y,

            [Symbol("vm64z", "A vector array of memory operands specified using VSIB memory addressing. The array of memory addresses are specified using a common base register, a constant scale factor, and a vector index register with individual elements of 64-bit index value in a ZMM register")]
            vm64z
        }

        /// <summary>
        /// "Identifies a variable that represents a memory offset, used by some variants of the MOV instruction. The actual address is given by a simple offset relative to the segment base. No ModR/M byte is used in the instruction. The number shown with moffs indicates its size, which is determined by the address-size attribute of the instruction "
        /// </summary>
        [SymSource(tokens)]
        public enum MoffsToken : byte
        {
            [Symbol("moffs8", "A segbase-relative address of width 8")]
            moffs8 = NativeSizeCode.W8,

            [Symbol("moffs16", "A segbase-relative address of width 16")]
            moffs16 = NativeSizeCode.W16,

            [Symbol("moffs32", "A segbase-relative address of width 32")]
            moffs32 = NativeSizeCode.W32,

            [Symbol("moffs64", "A segbase-relative address of width 64")]
            moffs64 = NativeSizeCode.W64,
        }

        [SymSource(tokens)]
        public enum RelToken: byte
        {
            [Symbol("rel8", "A relative address in the range from 128 bytes before the end of the instruction to 127 bytes after the end of the instruction")]
            rel8 = NativeSizeCode.W8,

            [Symbol("rel16", "A relative address within the same code segment as the instruction assembled, and applicable to instructions with an operand-size attribute of 16 bits")]
            rel16 = NativeSizeCode.W16,

            [Symbol("rel32", "A relative address within the same code segment as the instruction assembled. and applicable to instructions with an operand-size attribute of 32 bits")]
            rel32 = NativeSizeCode.W32,
        }

        [SymSource(tokens)]
        public enum MemPairToken : byte
        {
            [Symbol("m16&16", "A memory operand that defines a 16-bit x 16-bit pair")]
            m16x16,

            [Symbol("m16&32", "A memory operand that defines a 16-bit x 32-bit pair")]
            m16x32,

            [Symbol("m32&32", "A memory operand that defines a 32-bit x 32-bit pair")]
            m32x32,

            [Symbol("m16&64", "A memory operand that defines a 16-bit x 64-bit pair")]
            m16x64,
        }

        [SymSource(tokens)]
        public enum PtrToken : byte
        {
            [Symbol("ptr16:16", "A far pointer typically to a code segment different from that of the instruction. The notation 16:16 indicates that the value of the pointer has two parts. The value to the left of the colon is a 16- bit selector or value destined for the code segment register. The value to the right corresponds to the offset within the destination segment. The ptr16:16 symbol is used when the instruction's operand-size attribute is 16 bits E.G, CALL ptr16:16 (Call far, absolute, address given in operand")]
            Ptr16x16,

            [Symbol("ptr16:32", "A far pointer typically to a code segment different from that of the instruction and similar to ptr16:16 notation; in this case the ptr16:32 symbol is used when the operand-size attribute is 32 bits A memory operand using SIB addressing form, where the index register is not used in address calculation, Scale is ignored. Only the base and displacement are used in effective address calculation E.G, CALL ptr16:32 (Call far, absolute, address given in operand)")]
            Ptr16x32,

            [Symbol("m16:16", "A far pointer defined by a 16-bit segment selector an 16-bit offset")]
            MemPtr16x16,

            [Symbol("m16:32", "A far pointer defined by a 16-bit segment selector a 32-bit offset")]
            MemPtr16x32,

            [Symbol("m16:64", "A far pointer defined by a 16-bit segment selector a 64-bit offset")]
            MemPtr16x64
        }

        [SymSource(tokens)]
        public enum SrcOpToken : byte
        {
            [Symbol("SRC", "The source in a single-source instruction")]
            SRC,

            [Symbol("SRC1", "Denotes the first source operand in the instruction syntax of an instruction encoded with the VEX/EVEX prefix and having two or more source operands")]
            SRC1,

            [Symbol("SRC2", "Denotes the second source operand in the instruction syntax of an instruction encoded with the VEX/EVEX prefix and having two or more source operands")]
            SRC2,

            [Symbol("SRC3", "Denotes the third source operand in the instruction syntax of an instruction encoded with the VEX/EVEX prefix and having three source operands")]
            SRC3,
        }

        [SymSource(tokens)]
        public enum OpMaskToken : byte
        {
            [Symbol("{k1}", "A mask register used as instruction writemask for instructions that do not allow zeroing-masking but support merging-masking")]
            rK,

            [Symbol("{z}")]
            z,

            [Symbol("{k1}{z}", "A mask register used as instruction writemask")]
            rKz,
        }

        [SymSource(tokens)]
        public enum BroadcastToken
        {
            [Symbol("m32bcst", "Represents a 32-bit memory location that defines a scalar to broadcast to vector operands")]
            m32bcast,

            [Symbol("m64bcst", "Represents a 64-bit memory location that defines a scalar to broadcast to vector operands")]
            m64bcast,

            [Symbol("zmm/m512/m32bcst", "Represents a zmm vector, a 512-bit memory location or a 512-bit memory location or a 512-bit vector loaded from a 32-bit memory location")]
            z512x32bcst,

            [Symbol("zmm/m512/m64bcst", "Represents a zmm vector, a 512-bit memory location or a 512-bit memory location or a 512-bit vector loaded from a 64-bit memory location")]
            z512x64bcst,

        }

        [SymSource(tokens)]
        public enum RoundingToken : byte
        {
            [Symbol("{sae}")]
            sae,

            [Symbol("{er}")]
            er,
        }
    }
}