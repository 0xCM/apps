//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IFloat : IScalar
    {

    }

    [Free]
    public interface IFloat<T> : IFloat, IScalar<T>
        where T : unmanaged
    {

    }
}