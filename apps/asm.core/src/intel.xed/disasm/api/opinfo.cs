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