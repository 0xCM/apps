//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [MethodImpl(Inline), Op]
        public static ref Nonterminals nonterms(bool premise, in RuleStatement src, ref Nonterminals dst)
        {
            var criteria = premise ? ref src.Premise : ref src.Consequent;
            for(var i=0; i<criteria.Count; i++)
            {
                ref readonly var c = ref criteria[i];
                if(c.IsNonTerminal)
                    dst.Include(c.ToNonTerminal());
            }
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref Nonterminals nonterms(Index<RuleCriterion> src, ref Nonterminals dst)
        {
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var c = ref src[i];
                if(c.IsNonTerminal)
                    dst.Include(c.ToNonTerminal());
            }

            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref Nonterminals nonterms(in RuleTable src, ref Nonterminals dst)
        {
            for(var i=0; i<src.EntryCount; i++)
            {
                nonterms(true, src[i], ref dst);
                nonterms(false, src[i], ref dst);
            }
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref Nonterminals nonterms(bool premise, in RuleTable src, ref Nonterminals dst)
        {
            for(var i=0; i<src.EntryCount; i++)
                nonterms(premise, src[i], ref dst);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static Nonterminals nonterms(in RuleTable src)
        {
            var dst = Nonterminals.create();
            nonterms(src, ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Nonterminals nonterms(bool premise, in RuleTable src)
        {
            var dst = Nonterminals.create();
            for(var i=0; i<src.EntryCount; i++)
                nonterms(premise, src[i], ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static Nonterminals nonterms(bool premise, in RuleStatement src)
        {
            var dst = Nonterminals.create();
            nonterms(premise, src, ref dst);
            return dst;
        }


        [MethodImpl(Inline), Op]
        public static Nonterminals nonterms(Index<RuleCriterion> src)
        {
            var dst = Nonterminals.create();
            return nonterms(src, ref dst);
        }
    }
}