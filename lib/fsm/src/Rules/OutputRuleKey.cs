//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a key for output rule indexing/lookup
    /// </summary>
    /// <typeparam name="S">The state type</typeparam>
    public readonly struct OutputRuleKey<E,S> : IRuleKey<E,S>
    {
        public E Trigger {get;}

        public S Source {get;}

        /// <summary>
        /// The invariant hash
        /// </summary>
        public int Hash {get;}

        [MethodImpl(Inline)]
        public OutputRuleKey(E trigger, S target)
        {
            Trigger = trigger;
            Source = target;
            Hash = HashCode.Combine(trigger,target);
        }

        public override string ToString()
            => $"({Trigger}, {Source})";

        [MethodImpl(Inline)]
        public static implicit operator OutputRuleKey<E,S>((E trigger, S source) x)
            => new OutputRuleKey<E,S>(x.trigger, x.source);
    }
}