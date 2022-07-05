//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public interface IProject : IComponent
    {

    }

    public interface IProject<P> : IProject, IComponent<P>
        where P : IProject<P>, new()
    {

    }
}