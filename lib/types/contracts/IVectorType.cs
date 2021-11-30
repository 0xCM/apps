//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVectorType : ISizedType
    {
        uint CellCount {get;}

        BitWidth CellWidth {get;}

        BitWidth ISizedType.ContentWidth
            => CellCount*CellWidth;
    }

    public interface IVectorType<T> : IVectorType, ISizedType<T>
        where T : IVectorType<T>, new()
    {
    }
}