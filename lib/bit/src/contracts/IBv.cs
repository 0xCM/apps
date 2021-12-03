//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBv : ISizedType
    {

    }

    [Free]
    public interface IBv<T> : IBv, ISizedType<T>
        where T : unmanaged
    {

    }
}