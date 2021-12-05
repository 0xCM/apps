//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalarValue : ISizedValue
    {

    }

    [Free]
    public interface IScalarValue<T> : IScalarValue, ISizedValue<T>
        where T : unmanaged
    {

    }
}