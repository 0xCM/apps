//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public interface IWorkspace : IEntity
    {

    }

    public interface IWorkspace<W> : IWorkspace, IEntity<W>
        where W : IEntity<W>, new()
    {

    }
}