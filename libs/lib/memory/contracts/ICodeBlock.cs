//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICodeBlock<T> : ICodeBlock, IDataType<T>
        where T : ICodeBlock<T>
    {

    }

    [Free]
    public interface ICodeBlock : IByteSeq, IAddressable, IDataTypeExpr
    {

    }
}