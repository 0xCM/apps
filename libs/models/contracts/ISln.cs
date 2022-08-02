//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Contracts
{
    public interface ISln : IEntity
    {

    }

    public interface ISln<S> : ISln, IEntity<S>
        where S : ISln<S>, new()
    {

    }
}