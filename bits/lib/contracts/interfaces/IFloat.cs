//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IFloat : IScalarValue
    {

    }

    [Free]
    public interface IFloat<T> : IFloat, IScalarValue<T>
        where T : unmanaged
    {

    }
}