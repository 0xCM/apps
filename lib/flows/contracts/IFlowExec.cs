//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFlowExec : IDataFlow
    {
        IDataFlow Flow {get;}

        IActor IDataFlow.Actor
            => Flow.Actor;
    }

    public interface IFlowExec<S,T> : IFlowExec, IDataFlow<S,T>
    {


    }
}