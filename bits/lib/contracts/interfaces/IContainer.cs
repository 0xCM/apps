//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a parametric container
    /// </summary>
    /// <typeparam name="C"></typeparam>
    [Free]
    public interface IContainer<C>
    {

    }

    [Free]
    public interface IContainer<F,T> : IContainer<F>
        where F : IContainer<F,T>, new()
    {

    }
}