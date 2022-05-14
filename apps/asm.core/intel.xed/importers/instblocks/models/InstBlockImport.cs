//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedImport
    {

        /*
            /*
                amd_3dnow_opcode: None
                attributes: LOCKABLE
                avx512_tuple: None
                avx512_vsib: None
                avx_vsib: None
                broadcast_allowed: False
                category: BINARY
                cpl: 3
                cpuid: ['N/A']
                default_64b: False
                easz: aszall
                element_size: None
                eosz: oszall
                explicit_operands: ['MEM', 'IMM']
                extension: BASE
                f2_required: False
                f3_required: False
                flags: MUST [ of-mod sf-mod zf-mod af-mod pf-mod cf-tst cf-mod ]
                has_imm8: True
                has_imm8_2: False
                has_immz: False
                has_modrm: True
                iclass: ADC
                iform: ADC_MEMv_IMMb
                imm_sz: 1
                implicit_operands: ['none']
                isa_set: I86
                lower_nibble: 3
                map: 0
                memop_rw: mem-rw
                mod_required: 00/01/10
                mode_restriction: unspecified
                no_prefixes_allowed: False
                ntname: INSTRUCTIONS
                opcode: 0x83
                opcode_base10: 131
                operand_list: ['MEM0:rw:v', 'IMM0:r:b:i8']
                operands: MEM0:rw:v IMM0:r:b:i8
                osz_required: False
                parsed_operands: [<opnds.operand_info_t object at 0x00000169CB35D730>, <opnds.operand_info_t object at 0x00000169CB35D760>]
                partial_opcode: False
                pattern: 0x83 MOD[mm] MOD!=3 REG[0b010] RM[nnn] MODRM() SIMM8() LOCK=0
                real_opcode: Y
                reg_required: 2
                rexw_prefix: unspecified
                rm_required: unspecified
                scalar: False
                sibmem: False
                space: legacy
                undocumented: False
                upper_nibble: 8
                vl: n/a
                EOSZ_LIST: [16, 32, 64]
            */

        [StructLayout(StructLayout,Pack=1), Record(TableId)]
        public struct InstBlockImport
        {
            public const string TableId = "xed.instblock.import";

            public uint Seq;

            public InstClass Class;

            public InstForm Form;

            public InstPatternBody Pattern;

            public static InstBlockImport Empty => default;
        }
    }
}