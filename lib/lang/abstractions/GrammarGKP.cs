//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Grammar<G,K,P>
        where G : Grammar<G,K,P>
        where K : unmanaged
        where P : IProduction
    {
        public Label Name {get; protected set;}

        /// <summary>
        /// Specifies the symbols covered by the grammar
        /// </summary>
        public Alphabet<K> Alphabet {get; protected set;}

        protected DataList<P> Productions {get;}

        protected Grammar()
        {
            Alphabet = default;
        }

        protected Grammar(Label name)
        {
            Name = name;
        }

        protected Grammar(Label name, Alphabet<K> alphabet)
        {
            Name = name;
            Alphabet = alphabet;
        }

        public void Add(P rule)
        {
            Productions.Add(rule);
        }

        [MethodImpl(Inline)]
        public ref readonly K Symbol(uint index)
            => ref Alphabet[index];
    }
}