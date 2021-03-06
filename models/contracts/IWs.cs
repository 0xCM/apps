//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public interface IWs : IEntity
    {

    }

    public interface IWs<W> : IWs, IEntity<W>
        where W : IEntity<W>, new()
    {

    }
}