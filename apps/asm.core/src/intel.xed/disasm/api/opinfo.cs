//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        // OpSpec                                      | Opval
        // MEM0/R/SPW/SUPPRESSED/IMM_CONST/1           | MEM0:ptr [RSP]
        // MEM0/R/VV/EXPLICIT/IMM_CONST/1              | MEM0:ptr [RDX]

        // REG0/W/V/EXPLICIT/NT_LOOKUP_FN/GPRV_B
        // REG0/W/V/EXPLICIT/NT_LOOKUP_FN/GPRV_B
        // REG0/R/SPW/SUPPRESSED/REG/STACKPOP
        // REG1/W/Y/SUPPRESSED/NT_LOOKUP_FN/RIP        |

        // REG0/W/MSKW/EXPLICIT/NT_LOOKUP_FN/MASK_R    | REG0:K0
        // REG1/R/MSKW/EXPLICIT/NT_LOOKUP_FN/MASK1     | REG1:K0
        // REG2/R/QQ/EXPLICIT/NT_LOOKUP_FN/YMM_N3      | REG2:YMM0

        // IMM0/R/B/EXPLICIT/IMM_CONST/1               | IMM0:0x4

        /*
        AND

        PATTERN   : 0x20 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM() nolock_prefix
        OPERANDS  : MEM0:rw:b REG0=GPR8_R():r

        PATTERN   : 0x20 MOD[0b11] MOD=3 REG[rrr] RM[nnn]
        OPERANDS  : REG0=GPR8_B():rw REG1=GPR8_R():r

        PATTERN   : 0x20 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM() lock_prefix
        OPERANDS  : MEM0:rw:b REG0=GPR8_R():r

        PATTERN   : 0x21 MOD[0b11] MOD=3 REG[rrr] RM[nnn]
        OPERANDS  : REG0=GPRv_B():rw REG1=GPRv_R():r

        PATTERN   : 0x21 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM() lock_prefix
        OPERANDS  : MEM0:rw:v REG0=GPRv_R():r

        PATTERN   : 0x22 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM()
        OPERANDS  : REG0=GPR8_R():rw MEM0:r:b

        PATTERN   : 0x23 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM()
        OPERANDS  : REG0=GPRv_R():rw MEM0:r:v

        PATTERN   : 0x24 SIMM8()
        OPERANDS  : REG0=XED_REG_AL:rw:IMPL IMM0:r:b:i8

        PATTERN   : 0x25 SIMMz()
        OPERANDS  : REG0=OrAX():rw:IMPL IMM0:r:z

        PATTERN   : 0x80 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() UIMM8() nolock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x80 MOD[0b11] MOD=3 REG[0b100] RM[nnn] UIMM8()
        OPERANDS  : REG0=GPR8_B():rw IMM0:r:b

        PATTERN   : 0x80 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() UIMM8() lock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x82 MOD[mm] MOD!=3 REG[0b100] RM[nnn] not64 MODRM() UIMM8() nolock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x82 MOD[0b11] MOD=3 REG[0b100] RM[nnn] not64 UIMM8()
        OPERANDS  : REG0=GPR8_B():rw IMM0:r:b

        PATTERN   : 0x82 MOD[mm] MOD!=3 REG[0b100] RM[nnn] not64 MODRM() UIMM8() lock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x83 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() SIMM8() nolock_prefix
        OPERANDS  : MEM0:rw:v IMM0:r:b:i8

        PATTERN   : 0x83 MOD[0b11] MOD=3 REG[0b100] RM[nnn] SIMM8()
        OPERANDS  : REG0=GPRv_B():rw IMM0:r:b:i8

        PATTERN   : 0x83 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() SIMM8() lock_prefix
        OPERANDS  : MEM0:rw:v IMM0:r:b:i8

        */

        public static Outcome opinfo(string src, out DisasmOpInfo dst)
        {
            dst = default;
            if(text.length(src) < 3)
                return (false,RP.Empty);

            var result = Outcome.Success;
            var data = span(src);

            var idx = text.trim(text.left(src,2));
            result = DataParser.parse(idx, out dst.Index);
            if(result.Fail)
                return (false,AppMsg.ParseFailure.Format(nameof(dst.Index), idx));

            var aspects = text.trim(text.right(src,2));
            var parts = text.split(aspects, Chars.FSlash);
            if(parts.Length != 6)
                return (false, string.Format("Unexpected number of operand aspects in {0}", aspects));

            var i=0;
            result = DataParser.eparse(skip(parts,i++), out dst.Kind);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Kind), skip(parts,i-1)));

            result = DataParser.eparse(skip(parts,i++), out dst.Action);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.WidthCode);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out VisibilityKind vis);
            if(result.Fail)
                return result;
            dst.Visiblity = (OpVisibility)vis;

            result = DataParser.eparse(skip(parts,i++), out dst.OpType);
            if(result.Fail)
                return result;

            dst.Selector = text.trim(skip(parts,i++));
            return result;
        }
    }
}