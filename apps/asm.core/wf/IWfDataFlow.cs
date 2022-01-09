//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfDataFlow : IDataFlow
    {
        dynamic Source {get;}

        dynamic Target {get;}
    }

    public interface IWfDataFlow<S,T> : IWfDataFlow, IDataFlow<S,T>
    {
        dynamic IWfDataFlow.Source
            => ((IArrow<S,T>)this).Source;

        dynamic IWfDataFlow.Target
            => ((IArrow<S,T>)this).Target;
    }
}