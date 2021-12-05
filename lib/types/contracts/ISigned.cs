//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISigned : IScalar
    {

    }

    [Free]
    public interface ISigned<T> : ISigned, IScalar<T>
        where T : unmanaged
    {
    }
}