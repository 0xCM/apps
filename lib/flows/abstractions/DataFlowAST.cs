//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class DataFlow<A,S,T> : IDataFlow<A,S,T>
        where A : IActor
    {
        public A Actor {get;}

        public S Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        public DataFlow(A actor, S src, T dst)
        {
            Actor = actor;
            Source = src;
            Target = dst;
        }

        public virtual string Format()
            => string.Format("{0}:{1} -> {2}", Actor, Source, Target);

        public override string ToString()
            => Format();

        S IArrow<S,T>.Source
            => Source;

        T IArrow<S,T>.Target
            => Target;
    }
}