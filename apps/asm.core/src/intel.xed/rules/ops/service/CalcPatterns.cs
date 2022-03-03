//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<RulePattern> CalcPatterns(RuleSetKind kind)
        {
            var src = LoadPatternInfo(kind);
            var opcodes = CalcOpCodes(src);
            var count = Require.equal(src.Count,opcodes.Count);
            var tokens = span<RuleToken>(32);
            var parser = new RulePatternParser(tokens);
            var dst = alloc<RulePattern>(count);
            for(var i=0; i<count; i++)
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
                seek(dst,i) = pattern(opcode.Class, opcode.Kind, opcode.Value, slice(tokens, 0, result.ParsedCount).ToArray());
            }

            return dst;
        }
    }
}