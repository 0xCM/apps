//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFormattableDataType : IDataType, IExpr
    {

    }

    [Free]
    public interface IFormattableDataType<T> : IFormattableDataType, IDataType<T>
        where T : IFormattableDataType<T>
    {

    }
}