//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IBv : ISizedValue
    {

    }

    [Free]
    public interface IBv<T> : IBv, ISizedValue<T>
        where T : unmanaged
    {

    }
}