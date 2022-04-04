//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;
    using static DataStores;

    partial class XedPatterns
    {
        public static S16<Nonterminal> nonterms(Index<RuleCell> src)
        {
            var Capacity = count16<Nonterminal>();
            var dst = alloc16<Nonterminal>((int)src.Count);
            var j=0;
            for(var i=0; i<src.Count && j<Capacity; i++)
            {
                ref readonly var data = ref src[i].Data;
                if(XedParsers.IsNontermCall(data))
                {
                    if(XedParsers.parse(data, out Nonterminal nt))
                        dst[j++] = nt;
                }
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static bool nonterm(in PatternOp src, out Nonterminal dst)
        {
            var result = XedPatterns.first(src.Attribs, OpAttribClass.Nonterminal, out var attrib);
            if(result)
                dst = attrib.ToNonTerm();
            else
                dst = Nonterminal.Empty;
            return result;
        }
    }
}