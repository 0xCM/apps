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
        public static Index<RuleTableCells> cells(in RuleTable src)
        {
            var buffer = alloc<RuleTableCells>(src.Body.Count);
            ref readonly var statements = ref src.Body;
            for(var j=0; j<statements.Count; j++)
            {
                var m = z8;
                ref var dst = ref seek(buffer,j);
                ref readonly var left = ref statements[j].Premise;
                for(var k=0; k<left.Count; k++)
                {
                    dst[m] = new RuleTableCell(true, m, src.TableKind, left[k]);
                    m++;
                }
                ref readonly var right = ref statements[j].Consequent;
                for(var k=0; k<right.Count; k++)
                {
                    dst[m] = new RuleTableCell(false, m, src.TableKind, right[k]);
                    m++;
                }
                dst.Count = m;
            }

            return buffer;
        }

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