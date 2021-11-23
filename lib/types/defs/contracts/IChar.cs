//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IChar : IScalar
    {

    }

    [Free]
    public interface IChar<T> : IChar, IValue<T>
        where T : unmanaged
    {

    }
}