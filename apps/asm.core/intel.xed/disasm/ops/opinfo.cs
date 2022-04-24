//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDisasm
    {
        /// <summary>
        /// Parses an operand disassembly line
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <remarks>
        /// For example:
        /// 0		REG0/W/ZU32/EXPLICIT/NT_LOOKUP_FN/ZMM_R3
        /// 3		MEM0/R/VV/EXPLICIT/IMM_CONST/1
        /// 3		BASE0/RW/SSZ/SUPPRESSED/NT_LOOKUP_FN/SRSP
        /// </remarks>
        static Outcome opinfo(string src, out OpInfo dst)
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
            result = XedParsers.parse(skip(parts,i++), out dst.Name);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Name), skip(parts,i-1)));

            dst.Kind = XedRules.opkind(dst.Name);

            result = DataParser.eparse(skip(parts,i++), out dst.Action);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.WidthCode);
            if(result.Fail)
                return result;

            result = XedParsers.parse(skip(parts,i++), out dst.Visibility);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.OpType);
            if(result.Fail)
                return result;

            var selector = text.trim(skip(parts,i++));
            dst.SelectorName = selector;
            XedParsers.parse(selector, out dst.Selector);
            return result;
        }
    }
}