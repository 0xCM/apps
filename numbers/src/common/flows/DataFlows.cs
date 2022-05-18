//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct DataFlows
    {
        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Identifier actor, S src, T dst)
            => new DataFlow<Actor,S,T>(actor,src,dst);

        [MethodImpl(Inline)]
        public static FlowId identify<A,S,T>(in DataFlow<A,S,T> src)
            where A : IActor
            where S : ITextual
            where T : ITextual
        {
            var a = alg.hash.marvin(src.Actor.Name.Format());
            var s = alg.hash.marvin(src.Source.Format());
            var t = alg.hash.marvin(src.Target.Format());
            return new FlowId(a,s,t);
        }

        [MethodImpl(Inline)]
        public static FlowId identify<S,T>(Identifier actor, S src, T dst)
            where S : ITextual
            where T : ITextual
                => identify(flow(actor, src, dst));
    }
}