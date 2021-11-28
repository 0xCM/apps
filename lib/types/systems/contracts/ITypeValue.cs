//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITypeValue : IValue
    {

    }

    [Free]
    public interface ITypeValue<V> : IValue<V>
        where V : unmanaged
    {

    }
}