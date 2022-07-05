//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public abstract record class Workspace<W> : Component<W>
        where W : Workspace<W>, new()
    {

    }

    public abstract record class Workspace<W,P> : Workspace<W>
        where W : Workspace<W,P>,new()
        where P : IProject, new()
    {

    }
}