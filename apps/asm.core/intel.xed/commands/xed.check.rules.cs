//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Asm;

    using static core;
    using static XedRules;
    using static XedPatterns;
    using static XedModels;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var traverser = XedPatterns.traverser(Wf);
            traverser.Traverse();
            var patterns = traverser.Patterns();
            var defs = traverser.Defs();
            var oplookup = traverser.Ops().GroupBy(x => x.PatternId).Select(x => (x.Key, (Index<OpSpec>)x.ToArray())).ToDictionary();
            var count = patterns.Count;
            var missing = list<InstPatternSpec>();
            for(var i=0; i<count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var body = ref pattern.Body;
                if(!oplookup.TryGetValue(pattern.PatternId, out _))
                    Require.invariant(pattern.Ops.Count == 0);
                ref readonly var ops = ref pattern.Ops;
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                }
            }

            return true;
        }
   }
}