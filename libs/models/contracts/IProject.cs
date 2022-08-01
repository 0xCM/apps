//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public interface IProject : IEntity
    {

    }

    public interface IProject<P> : IProject, IEntity<P>
        where P : IProject<P>, new()
    {

    }
}