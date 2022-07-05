//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public abstract record class Workspace<W,P> : Workspace<W>
        where W : Workspace<W,P>,new()
        where P : IProject, new()
    {

    }
}