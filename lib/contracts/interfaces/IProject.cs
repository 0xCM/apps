//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IProject
    {
        ProjectId Id {get;}
    }

    [Free]
    public interface IProject<T> : IProject
        where T : IProject<T>, new()
    {

    }
}