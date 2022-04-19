//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlow : IDataFlow
    {
        IFlowType FlowType {get;}

        IActor IDataFlow.Actor
            => FlowType.Actor;
    }

    public interface IFlow<S,T> : IFlow, IDataFlow<S,T>
    {


    }
}