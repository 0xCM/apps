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
    /// Encapsulates the set of all rules (input : E, source : S) -> target : S that define state machine transitions
    /// </summary>
    public class TransitionFunction<E,S> : IFsmFunc<E,S>
    {
        readonly Dictionary<int,ITransitionRule<E,S>> Index;

        public TransitionFunction(IEnumerable<ITransitionRule<E,S>> rules)
            => Index = rules.Select(x => (Fsm.transitionKey(x.Trigger,x.Source).Hash, x)).ToDictionary();

        public TransitionFunction(IEnumerable<TransitionRule<E,S>> rules)
            => Index = rules.Select(x => (Fsm.transitionKey(x.Trigger,x.Source).Hash, x as ITransitionRule<E,S>)).ToDictionary();

        [MethodImpl(Inline)]
        public Option<S> Eval(E input, S source)
            => Rule(Fsm.transitionKey(input,source)).TryMap(r => r.Target);

        public Option<ITransitionRule<E,S>> Rule(IRuleKey key)
        {
            if(Index.TryGetValue(key.Hash, out ITransitionRule<E,S> dst))
                return Option.some(dst);
            else
                return default;
        }

        Option<IFsmRule> IFsmFunc.Rule(IRuleKey key)
            => Rule(key).TryMap(r => r as IFsmRule);

        /// <summary>
        /// Specifies the set of events that can effect a transition
        /// </summary>
        public IEnumerable<E> Triggers
            => Index.Values.Select(x => x.Trigger).Distinct();
    }
}