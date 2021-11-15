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
    /// Identifies an action rule for lookup purposes
    /// </summary>
    /// <typeparam name="S">The state type</typeparam>
    public readonly struct ActionRuleKey<S> : IRuleKey
    {
        public int Hash {get;}

        public S Source {get;}

        [MethodImpl(Inline)]
        public ActionRuleKey(S source)
        {
            Source = source;
            Hash = source.GetHashCode();
        }

        public readonly override string ToString()
            => $"({Source})";

        [MethodImpl(Inline)]
        public static implicit operator ActionRuleKey<S>(S source)
            => new ActionRuleKey<S>(source);
    }
}