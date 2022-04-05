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
        public static ref FunctionSet functions(bool premise, in RuleStatement src, ref FunctionSet dst)
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
        public static ref FunctionSet functions(Index<RuleCriterion> src, ref FunctionSet dst)
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
        public static ref FunctionSet functions(in RuleTable src, ref FunctionSet dst)
        {
            for(var i=0; i<src.EntryCount; i++)
            {
                functions(true, src[i], ref dst);
                functions(false, src[i], ref dst);
            }
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref FunctionSet functions(bool premise, in RuleTable src, ref FunctionSet dst)
        {
            for(var i=0; i<src.EntryCount; i++)
                functions(premise, src[i], ref dst);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static FunctionSet nonterms(in RuleTable src)
        {
            var dst = FunctionSet.create();
            functions(src, ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static FunctionSet functions(bool premise, in RuleTable src)
        {
            var dst = FunctionSet.create();
            for(var i=0; i<src.EntryCount; i++)
                functions(premise, src[i], ref dst);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static FunctionSet functions(bool premise, in RuleStatement src)
        {
            var dst = FunctionSet.create();
            functions(premise, src, ref dst);
            return dst;
        }


        [MethodImpl(Inline), Op]
        public static FunctionSet functions(Index<RuleCriterion> src)
        {
            var dst = FunctionSet.create();
            return functions(src, ref dst);
        }
    }
}