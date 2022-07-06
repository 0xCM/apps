//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IHexNumber : INumeric
    {

    }

    public interface IHexNumber<K> : IHexNumber, INumeric<K>
        where K : unmanaged
    {

    }

    public interface IHexNumber<F,W,K> : IHexNumber<K>
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