//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IUnsigned : IScalar
    {
    }

    [Free]
    public interface IUnsigned<T> : IUnsigned, IScalar<T>
        where T : unmanaged
    {

    }
}