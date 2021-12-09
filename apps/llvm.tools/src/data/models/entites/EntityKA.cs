//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public abstract class Entity<K,A>
    {
        protected Dictionary<K,A> Lookup;

        protected Index<A> AttribIndex;

        public ReadOnlySpan<A> Attributes
        {
            [MethodImpl(Inline)]
            get => AttribIndex;
        }

        public virtual A this[K field]
        {
            get
            {
                if(Lookup.TryGetValue(field, out var value))
                    return value;
                else
                    return EmptyAttribute;
            }
        }

        protected A Attrib(K field)
            => this[field];

        protected Entity(A[] src)
        {
            AttribIndex = src;
            Lookup = new();
            var count = src.Length;
            var keyf = KeyFunction;
            foreach(var field in src)
            {
                if(!Lookup.TryAdd(keyf(field), field))
                {

                }
            }
        }

        protected virtual A EmptyAttribute => default;

        protected abstract Func<A,K> KeyFunction {get;}
    }
}