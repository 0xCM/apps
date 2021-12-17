//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IUnsignedInteger : IScalarValue
    {
    }

    [Free]
    public interface IUnsignedInteger<T> : IUnsignedInteger, IScalarValue<T>
        where T : unmanaged
    {

    }
}