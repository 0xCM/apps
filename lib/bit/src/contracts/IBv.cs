//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBv : IBlittable
    {

    }

    [Free]
    public interface IBv<T> : IBv, IBlittable<T>
        where T : unmanaged
    {

    }
}