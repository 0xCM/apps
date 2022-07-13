//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IPredicate : IFunc<object,bool>, IExprDeprecated
    {

    }

    [Free]
    public interface IPredicate<T> : IFunc<T,bool>, IExprDeprecated
    {

    }


    public interface IConversionOp<S,T> : IFunc, IExprDeprecated
    {

    }
}