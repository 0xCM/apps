//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IContext
    {
        dynamic State {get;}
    }

    public interface IContext<T> : IContext
        where T : IContext<T>
    {
        dynamic IContext.State
            => (T)this;
    }
}