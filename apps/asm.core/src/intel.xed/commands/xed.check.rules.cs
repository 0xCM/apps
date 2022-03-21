//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using static core;
    using static XedRules;
    using static XedPatterns;

    partial class XedCmdProvider
    {

        [CmdOp("xed/check/rules")]
        Outcome CheckRuleSpecs(CmdArgs args)
        {
            var traverser = XedPatterns.traverser(Wf);
            traverser.Traverse();
            var patterns = traverser.Patterns();
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
                //Write(body.Format());
                for(var j=0; j<ops.Count; j++)
                {
                    ref readonly var op = ref ops[j];
                    //Write(op.Format());
                }
            }

            return true;
        }
    }
}