//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a partial state machine output function of the form
    /// (source : S, target : S) -> output : Option[O]
    /// for source/target pairs in the domain. If an input value (s1:S, s2:S)
    /// is not in the function domain, en empty option is returned
    /// </summary>
    public class OutputFunction<E,S,O> : IFsmFunc
    {
        readonly Dictionary<int,IOutputRule<E,S,O>> RuleIndex;

        [MethodImpl(Inline)]
        public OutputFunction(IEnumerable<IOutputRule<E,S,O>> Rules)
            => RuleIndex = Rules.Select(x => (Fsm.outKey(x.Trigger, x.Source).Hash,x)).ToDictionary();

        /// <summary>
        /// Computes the output value, if any, for a specified source state and event
        /// </summary>
        /// <param name="trigger">The incoming event</param>
        /// <param name="source">The source state</param>
        [MethodImpl(Inline)]
        public Option<O> Output(E trigger, S source)
            => Rule(Fsm.outKey(trigger, source)).TryMap(r => r.Output);

        /// <summary>
        /// Searches for the output rule given a key
        /// </summary>
        /// <param name="key">The rule key</param>
        public Option<IOutputRule<E,S,O>> Rule(IRuleKey key)
        {
            if(RuleIndex.TryGetValue(key.Hash, out IOutputRule<E,S,O> dst))
                return Option.some(dst);
            else
                return default;
        }

        [MethodImpl(Inline)]
        Option<IFsmRule> IFsmFunc.Rule(IRuleKey key)
            => Rule(key).TryMap(r => r as IFsmRule);
    }
}