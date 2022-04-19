//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface IGridPoint : ITextual
    {
        uint Row {get;}

        uint Col {get;}

        string ITextual.Format()
            => $"({Row},{Col})";
    }

    public interface IGridPoint<F> : IGridPoint
        where F : unmanaged, IGridPoint<F>
    {

    }

    public interface IGridPoint<F,T> : IGridPoint<F>
        where F : unmanaged, IGridPoint<F,T>
        where T : unmanaged
    {
        new T Row {get;}

        new T Col {get;}

        uint IGridPoint.Row
            => uint32(Row);

        uint IGridPoint.Col
            => uint32(Col);
    }
}