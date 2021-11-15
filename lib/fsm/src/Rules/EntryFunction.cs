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
    /// Defines a set of rules that define actions associated with state entry
    /// </summary>
    public readonly struct EntryFunction<S,A> : IFsmFunc
    {
        readonly Dictionary<int, IFsmActionRule<A>> RuleIndex;

        public EntryFunction(IEnumerable<IFsmActionRule<A>> rules)
            => RuleIndex = rules.Select(rule => (rule.RuleId, rule)).ToDictionary();

        public Option<A> Eval(S source)
            => Rule(Fsm.entryKey(source)).TryMap(r => r.Action);

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