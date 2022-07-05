//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public abstract record class Workspace<W> : Entity<W>
        where W : Workspace<W>, new()
    {

    }
}