//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public abstract class ValueProduction<S,T> : IValueProduction<S,T>
    {
        public S Source {get;}

        public T Target {get;}

        Value<S> IArrow<Value<S>, Value<T>>.Source
            => Source;

        Value<T> IArrow<Value<S>, Value<T>>.Target
            => Target;

        protected ValueProduction(S src, T dst)
        {
            Source = src;
            Target = dst;
        }

        public virtual string Format()
            => string.Format("{0} -> {1}", Source, Target);

        public override string ToString()
            => Format();
    }
}