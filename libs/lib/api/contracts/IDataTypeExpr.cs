//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDataTypeExpr : IDataType, IExpr2
    {

    }

    [Free]
    public interface IDataTypeExpr<T> : IDataTypeExpr, IDataType<T>
        where T : IDataTypeExpr<T>
    {

    }
}