//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVar : IExprDeprecated, ITerm
    {

    }

    [Free]
    public interface IVar<T> : IVar, ITerm
    {
        T Value {get;}
    }
}