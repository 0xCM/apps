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
        public static Index<RuleCell> cells(bool premise, string src)
        {
            var dst = list<RuleCell>();
            var input = text.trim(text.despace(src));
            if(text.contains(input, Chars.Space))
            {
                var parts = text.split(input, Chars.Space);
                var count = parts.Length;
                for(var j=0; j<count; j++)
                {
                    ref readonly var part = ref skip(parts,j);
                    if(RuleMacros.match(part, out var match))
                    {
                        var expanded = text.trim(match.Expansion);
                        if(text.contains(expanded, Chars.Space))
                        {
                            var expansions = text.split(expanded, Chars.Space);
                            for(var k=0; k<expansions.Length; k++)
                            {
                                ref readonly var x = ref skip(expansions,k);
                                dst.Add(new (premise, x));
                            }
                        }
                        else
                            dst.Add(new (premise, expanded));
                    }
                    else
                        dst.Add(new (premise, part));
                }
            }
            else
            {
                if(RuleMacros.match(input, out var match))
                    dst.Add(new (premise, match.Expansion));
                else
                    dst.Add(new (premise, input));
            }
            return dst.ToArray();
        }
    }
}