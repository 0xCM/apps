//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataFlow]
    public abstract class Flow<S,T> : IDataFlow<S,T>
    {
        public IFlowType FlowType {get;}

        public S Source {get;}

        public T Target {get;}

        public IActor Actor => FlowType.Actor;

        public string Descriptor
            => FlowType.Format();

        protected Flow(IFlowType flow, S src, T dst)
        {
            FlowType = flow;
            Source =src;
            Target = dst;
        }
    }
}