//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a set of rules that define actions associated with state Exit
    /// </summary>
    public class ExitFunction<S,A> : IFsmFunc
    {
        public ExitFunction(IEnumerable<IFsmActionRule<A>> rules)
            => RuleIndex = rules.Select(rule => (rule.RuleId, rule)).ToDictionary();

        readonly Dictionary<int, IFsmActionRule<A>> RuleIndex;

        public Option<A> Eval(S source)
            => Rule(Fsm.exitKey(source)).TryMap(r => r.Action);

        public Option<IFsmActionRule<A>> Rule(IRuleKey key)
        {
            if(RuleIndex.TryGetValue(key.Hash, out IFsmActionRule<A> dst))
                return Option.some(dst);
            else
                return default;
        }

        Option<IFsmRule> IFsmFunc.Rule(IRuleKey key)
            => Rule(key).TryMap(r => r as IFsmRule);
    }
}