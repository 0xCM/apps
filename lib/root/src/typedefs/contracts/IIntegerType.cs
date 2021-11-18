//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IIntegerType : ITypeDef
    {
        bool Signed {get;}

    }

    public interface IIntegerType<T> : IIntegerType
        where T : IIntegerType<T>, new()
    {

    }
}