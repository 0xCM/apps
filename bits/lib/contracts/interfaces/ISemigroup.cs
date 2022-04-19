//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISemigroup<T>
    {

    }

    [Free]
    public interface ISemigroup<F,T> : ISemigroup<T>
        where F : ISemigroup<F,T>, new()
    {

    }
}