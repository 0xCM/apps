//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalar : IValue
    {

    }

    [Free]
    public interface IScalar<T> : IScalar, IValue<T>
        where T : unmanaged
    {

    }
}