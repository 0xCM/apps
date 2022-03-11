//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        public Index<RulePattern> CalcPatterns()
        {
            return Data(nameof(CalcPatterns), Calc);

            Index<RulePattern> Calc()
            {
                var src = LoadPatternInfo();
                return CalcPatterns(src,CalcOpCodes(src));
            }
        }

        Index<RulePattern> CalcPatterns(Index<RulePatternInfo> src, Index<XedOpCode> opcodes)
        {
            var count = Require.equal(src.Count,opcodes.Count);
            var buffer = span<RuleToken>(32);
            var parser = new RulePatternParser(buffer);
            var dst = alloc<RulePattern>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var info = ref src[i];
                ref readonly var opcode = ref opcodes[i];
                var expr = info.Expression;
                var result = parser.Parse(expr);
                if(!result.Succeeded)
                {
                    Errors.Throw(string.Format("Parse incomplete: {0}/{1} succeeded", result.ParsedCount, result.SourceCount));
                    break;
                }
                var tokens = slice(buffer, 0, result.ParsedCount).ToArray();
                seek(dst,i) = pattern(i, opcode.Class, opcode.Kind, ocvalue(tokens), tokens);
            }

            return dst;
        }
    }
}