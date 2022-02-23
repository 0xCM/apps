//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataFlow<A,S,T> : IDataFlow<A,S,T>
        where A : IActor
    {
        public readonly A Actor;

        public readonly S Source;

        public readonly T Target;

        [MethodImpl(Inline)]
        public DataFlow(A actor, S src, T dst)
        {
            Actor = actor;
            Source = src;
            Target = dst;
        }

        public string Format()
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