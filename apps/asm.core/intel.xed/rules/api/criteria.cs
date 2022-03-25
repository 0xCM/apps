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
        static Index<RuleCriterion> criteria(bool premise, ReadOnlySpan<RuleCell> src)
        {
            var dst = list<RuleCriterion>();
            var parts = map(src, p => p.Format());
            for(var i=0; i<parts.Length; i++)
            {
                ref readonly var part = ref skip(parts, i);
                var result = parse(premise, part, out var c);
                if(!result)
                    Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleCriterion), part));

                dst.Add(c);
            }
            return dst.ToArray();
        }
    }
}