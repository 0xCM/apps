//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public interface IIndexedBits
    {
        bit this[uint i] {get;set;}
    }

    [Free]
    public interface IIndexedBits<T> : IIndexedBits, IBv<T>
        where T : unmanaged
    {
    }
}