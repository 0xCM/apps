//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IHexNumber : IByte
    {
        bool IsZero {get;}

        bool IsNonZero {get;}
    }

    public interface IHexNumber<K> : IHexNumber
        where K : unmanaged
    {
        new K Value {get;}

        byte IByte.Value
            => (byte)(object)Value;
    }

    public interface IHexNumber<F,K> : IHexNumber<K>, IByte<F>, IComparable<F>, IEquatable<F>, ITextual
        where F : unmanaged, IHexNumber<F,K>
        where K : unmanaged
    {

    }

    public interface IHexNumber<F,W,K> : IHexNumber<F,K>
        where F : unmanaged, IHexNumber<F,W,K>
        where K : unmanaged
        where W : unmanaged, IDataWidth
    {
        BitWidth ISized.Width
            => default(W).BitWidth;

        ByteSize ISized.Size
            => default(W).BitWidth/8;
    }
}