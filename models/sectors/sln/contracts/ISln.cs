//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public interface ISln : IComponent
    {

    }

    public interface ISln<S> : ISln, IComponent<S>
        where S : ISln<S>, new()
    {

    }
}