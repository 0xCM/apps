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

    [Free]
    public interface IVar<N,T> : IVar<T>, INamed<N>
        where N : unmanaged, INamed
    {
        new N Name {get;}

        VarSymbol IVar.Name
            => new VarSymbol(Name.Name);
    }
}