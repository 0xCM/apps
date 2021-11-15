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
    /// Characterizes an action that that executes per machine rules
    /// </summary>
    public readonly struct ActionRule<S,A> : IFsmActionRule<S,A>
    {
        /// <summary>
        /// The state upon which the rule is predicated
        /// </summary>
        public S Source {get;}

        /// <summary>
        /// The action invoked
        /// </summary>
        public A Action {get;}

        /// <summary>
        /// The rule key
        /// </summary>
        public ActionRuleKey<S> Key {get;}

        /// <summary>
        /// The rule identifier
        /// </summary>
        public readonly int RuleId
        {
            [MethodImpl(Inline)]
            get => Key.Hash;
        }

        [MethodImpl(Inline)]
        public ActionRule(S source, A action)
        {
            Source = source;
            Action= action;
            Key = new ActionRuleKey<S>(source);
        }


        public readonly override string ToString()
            => $"({Source}) -> {Action}";

        /// <summary>
        /// Constructs a rule from a source/action pair
        /// </summary>
        /// <param name="src">The source state</param>
        /// <param name="action">The action</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="A">The action type</typeparam>
        [MethodImpl(Inline)]
        public static implicit operator ActionRule<S,A>((S src, A action) x)
            => new ActionRule<S,A>(x.src, x.action);
    }
}