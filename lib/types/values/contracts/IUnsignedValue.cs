//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IUnsignedValue : IScalarValue
    {
    }

    [Free]
    public interface IUnsignedValue<T> : IUnsignedValue, IScalarValue<T>
        where T : unmanaged
    {

    }
}