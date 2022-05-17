//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVar : IExpr, ITerm
    {
        VarSymbol Name {get;}
    }

    [Free]
    public interface IVar<T> : IVar, ITerm
    {
        T Value {get;}
    }
}