//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FlowExec<S,T> : IFlowExec<S,T>
    {
        public IDataFlow Flow {get;}

        public S Source {get;}

        public T Target {get;}

        public IActor Actor => Flow.Actor;

        public string Descriptor
            => Flow.Format();

        protected FlowExec(IDataFlow flow, S src, T dst)
        {
            Flow = flow;
            Source =src;
            Target = dst;
        }
    }
}