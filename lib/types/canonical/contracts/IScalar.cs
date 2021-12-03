//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalar : ISizedType
    {

    }

    [Free]
    public interface IScalar<T> : IScalar, ISizedType<T>
        where T : unmanaged
    {

    }
}