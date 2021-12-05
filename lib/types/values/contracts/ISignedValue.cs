//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISignedValue : IScalarValue
    {

    }

    [Free]
    public interface ISignedValue<T> : ISignedValue, IScalarValue<T>
        where T : unmanaged
    {
    }
}