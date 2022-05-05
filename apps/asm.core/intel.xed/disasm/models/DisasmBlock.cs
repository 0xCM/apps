//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedDisasm
    {
        /*
            VPMULDQ VPMULDQ_ZMMi64_MASKmskw_ZMMi32_ZMMi32_AVX512 EASZ:3, EOSZ:3, HAS_MODRM:1, LLRC:2, LZCNT, MAP:2, MASK:7, MAX_BYTES:15, MOD:3, MODE:2, MODRM_BYTE:244, NOMINAL_OPCODE:40, OUTREG:ZMM28, P4, POS_MODRM:5, POS_NOMINAL_OPCODE:4, REG:6, REG0:ZMM30, REG1:K7, REG2:ZMM29, REG3:ZMM28, REXB, REXR, REXRR, REXW, REXX, RM:4, SMODE:2, TZCNT, UBIT, VEXDEST210:2, VEXDEST4, VEXVALID:2, VEX_PREFIX:1, VL:2, ZEROING
            0		REG0/W/ZI64/EXPLICIT/NT_LOOKUP_FN/ZMM_R3
            1		REG1/R/MSKW/EXPLICIT/NT_LOOKUP_FN/MASK1
            2		REG2/R/ZI64/EXPLICIT/NT_LOOKUP_FN/ZMM_N3
            3		REG3/R/ZI64/EXPLICIT/NT_LOOKUP_FN/ZMM_B3
            YDIS: vpmuldq zmm30{k7}{z}, zmm29, zmm28
            XDIS c: AVX512    AVX512EVEX 620295C728F4             vpmuldq zmm30{k7}{z}, zmm29, zmm28

            VPMULDQ VPMULDQ_ZMMi64_MASKmskw_ZMMi32_MEMi32_AVX512 EASZ:3, ELEMENT_SIZE:64, EOSZ:3, HAS_MODRM:1, LLRC:2, LZCNT, MAP:2, MAX_BYTES:15, MEM0:ptr [RCX], MODE:2, MODRM_BYTE:49, NELEM:8, NOMINAL_OPCODE:40, OUTREG:ZMM29, P4, POS_MODRM:5, POS_NOMINAL_OPCODE:4, REG:6, REG0:ZMM30, REG1:K0, REG2:ZMM29, REXR, REXRR, REXW, RM:1, SMODE:2, TZCNT, UBIT, USING_DEFAULT_SEGMENT0, VEXDEST210:2, VEXDEST4, VEXVALID:2, VEX_PREFIX:1, VL:2
            0		REG0/W/ZI64/EXPLICIT/NT_LOOKUP_FN/ZMM_R3
            1		REG1/R/MSKW/EXPLICIT/NT_LOOKUP_FN/MASK1
            2		REG2/R/ZI64/EXPLICIT/NT_LOOKUP_FN/ZMM_N3
            3		MEM0/R/VV/EXPLICIT/IMM_CONST/1
            YDIS: vpmuldq zmm30, zmm29, zmmword ptr [rcx]
            XDIS 12: AVX512    AVX512EVEX 626295402831             vpmuldq zmm30, zmm29, zmmword ptr [rcx]
        */
        /// <summary>
        /// Represents the content of a verbose xed instruction disassembly
        /// </summary>
        public readonly struct DisasmBlock
        {
            public readonly Index<TextLine> Lines;

            [MethodImpl(Inline)]
            public DisasmBlock(TextLine[] src)
            {
                Lines = src;
            }

            public bool IsValid
            {
                [MethodImpl(Inline)]
                get => Lines.Count >= 3;
            }

            public bool IsEmtpy
            {
                [MethodImpl(Inline)]
                get => Lines.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Lines.IsEmpty;
            }

            public uint OpCount
            {
                [MethodImpl(Inline)]
                get => Lines.Count - 3;
            }

            public ref readonly TextLine Props
            {
                [MethodImpl(Inline)]
                get => ref Lines.First;
            }

            public ReadOnlySpan<TextLine> Ops
            {
                [MethodImpl(Inline)]
                get => slice(Lines.View,1,OpCount);
            }

            public ref readonly TextLine YDis
            {
                [MethodImpl(Inline)]
                get  => ref Lines[Lines.Count - 2];
            }

            public ref readonly TextLine XDis
            {
                [MethodImpl(Inline)]
                get  => ref Lines.Last;
            }

            public Index<OpSpec> ParseOps()
                => ops(this);

            public uint ParseOps(Span<OpSpec> dst)
                => ops(this, dst);

            public AsmInfo ParseAsm()
                => asminfo(this);

            public InstFieldValues ParseProps()
                => XedDisasm.props(this);

            public string Format()
                => DisasmRender.format(this);

            public override string ToString()
                => Format();

            public static DisasmBlock Empty => new DisasmBlock(sys.empty<TextLine>());
        }
    }
}