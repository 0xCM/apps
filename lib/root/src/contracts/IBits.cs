//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IBits : IDataType
    {
        uint Width {get;}
    }

    public interface IBits<T> : IBits
        where T : unmanaged
    {
        T Value {get;}
    }

    public interface IBitContainer<H,T> : IBits<T>, IDataTypeEquatable<H>
        where H : unmanaged, IBitContainer<H,T>
        where T : unmanaged
    {

    }

    public interface IBits<N,T> : IBits<T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
    {

    }

    public interface IBitContainer<H,N,T> : IBits<N,T>, IBitContainer<H,T>
        where N : unmanaged, ITypeNat
        where T : unmanaged
        where H : unmanaged, IBitContainer<H,N,T>
    {

    }
}