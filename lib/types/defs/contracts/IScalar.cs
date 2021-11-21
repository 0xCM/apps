//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalar : IBlittable
    {

    }

    [Free]
    public interface IScalar<T> : IScalar, IBlittable<T>
        where T : unmanaged
    {

    }
}