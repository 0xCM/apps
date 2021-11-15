//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IBitNumber : IDataType, IHashed, ISized
    {
        Span<bit> Bits {get;}

        bool IsZero {get;}

        bool IsNonZero
            => !IsZero;
    }

    public interface IBitNumber<S> : IBitNumber, IEquatable<S>
        where S : unmanaged, IBitNumber<S>
    {

    }

    public interface IBitNumber<S,T> : IBitNumber<S>, INullary<S,T>, IDataType<T>
        where S : unmanaged, IBitNumber<S,T>
        where T : unmanaged
    {

    }

    public interface IBitNumber<S,W,T> : IBitNumber<S,T>
        where S : unmanaged, IBitNumber<S,W,T>
        where W : unmanaged, IDataWidth
        where T : unmanaged
    {
        BitWidth ISized.Width
            => default(W).BitWidth;
    }

    public interface IBitNumber<F,W,K,T> : IBitNumber<F,W,T>
        where F : unmanaged, IBitNumber<F,W,K,T>
        where W : unmanaged, IDataWidth
        where K : unmanaged
        where T : unmanaged
    {

    }
}