//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICpuVectorType : ITypeDef
    {

    }

    public interface ICpuVectorType<W> : ICpuVectorType, ISizedType
        where W : unmanaged, IDataWidth
    {
        BitWidth ISizedType.StorageWidth
            => Widths.data<W>();

        BitWidth ISizedType.ContentWidth
            => Widths.data<W>();
    }

    public interface ICpuVectorType<W,T> : ICpuVectorType<W>
        where W : unmanaged, IDataWidth
        where T : ICpuVectorType<W,T>, new()
    {

    }
}