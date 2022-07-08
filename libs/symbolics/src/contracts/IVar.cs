//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVar : IExpr
    {

    }

    [Free]
    public interface IVar<T> : IVar
    {
        T Value {get;}
    }
}