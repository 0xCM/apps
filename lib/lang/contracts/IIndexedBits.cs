//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public interface IIndexedBits : ISizedValue
    {
        bit this[uint i] {get;set;}
    }

    [Free]
    public interface IIndexedBits<T> : IIndexedBits, ISizedValue<T>
        where T : unmanaged
    {
        T IValue<T>.Value
            => core.@as<IIndexedBits<T>,T>(this);
    }
}