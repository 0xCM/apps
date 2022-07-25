//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDataExpr : IDataType, IExpr
    {

    }

    [Free]
    public interface IDataExpr<T> :  IDataExpr, IDataType<T>
        where T : IDataExpr<T>
    {

    }
}