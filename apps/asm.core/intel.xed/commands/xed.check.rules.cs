//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedCmdProvider
    {
        void CheckNonTerms()
        {
            var patterns = CalcPatterns();
            var count = patterns.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var fields = ref pattern.Fields;
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    if(op.Nonterminal(out var nt))
                    {
                        Require.invariant(nt.IsNonEmpty);
                        GprWidth.widths(nt, out var widths);
                        Write(string.Format("{0,-18} | {1}={2,-24} | {3}", pattern.InstClass, op.Name, nt, widths), FlairKind.StatusData);
                    }

                }
            }
        }

        void CheckGprWidths()
        {
            var ntk = RuleName.GPR8_R;
            var result = GprWidth.widths(ntk, out var widths);
            Write(widths.Format());
        }

        bool Match(Index<string> a, Index<string> b)
        {
            var result = true;
            var count = a.Count;
            result = (count == b.Count);
            if(result)
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var x = ref a[i];
                    ref readonly var y = ref b[i];
                    result = x == y;
                    if(!result)
                        break;
                }
            }

            return result;
        }
    }
}