//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataFlow]
    public abstract class DataFlow<F,A,S,T> : IDataFlow<A,S,T>
        where A : IActor
        where F : DataFlow<F,A,S,T>, new()
    {
        public static F Instance = new();

        public A Actor {get;}

        public S Source {get;}

        public T Target {get;}

        [MethodImpl(Inline)]
        protected DataFlow(A actor, S src, T dst)
        {
            Actor = actor;
            Source = src;
            Target = dst;
        }

        public virtual string Format()
            => string.Format("{0}:{1} -> {2}", Actor, Source, Target);

        public override string ToString()
            => Format();

        A IDataFlow<A,S,T>.Actor
            => Actor;

        S IArrow<S,T>.Source
            => Source;

        T IArrow<S,T>.Target
            => Target;

    }
}