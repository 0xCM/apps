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
            return Calc();

            Index<RulePattern> Calc()
            {
                var src = LoadPatternInfo(kind);
                var opcodes = CalcOpCodes(src);
                var count = Require.equal(src.Count,opcodes.Count);
                var tokens = span<RuleToken>(32);
                var parser = new RulePatternParser(tokens);
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
                    var _tokens = slice(tokens, 0, result.ParsedCount).ToArray();
                    seek(dst,i) = pattern(i,opcode.Class, opcode.Kind, ocvalue(_tokens), _tokens);
                }

                return dst;
            }
        }
    }
}