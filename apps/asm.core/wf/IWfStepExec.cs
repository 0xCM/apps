//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfStepExec : IWfDataFlow
    {
        IWfDataFlow Flow {get;}

        IActor IDataFlow.Actor
            => Flow.Actor;
    }

    public interface IWfStepExec<S,T> : IWfStepExec, IDataFlow<S,T>
    {
        dynamic IWfDataFlow.Source
            => ((IArrow<S,T>)this).Source;

        dynamic IWfDataFlow.Target
            => ((IArrow<S,T>)this).Target;
    }
}