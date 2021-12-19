//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = DataFlows;

    public abstract class DataFlow<A,S,T> : IDataFlow<A,S,T>
        where S : IType
        where T : IType
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

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        S IArrow<S,T>.Source
            => Source;

        T IArrow<S,T>.Target
            => Target;
    }
}