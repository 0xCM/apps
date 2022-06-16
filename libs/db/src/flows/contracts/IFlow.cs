//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Flows;

    public interface IFlow
    {
        string Format();
    }

    public interface IFlow<S,T> : IFlow, IArrow<S,T>
    {
        string IFlow.Format()
            => api.format(this);
    }
}