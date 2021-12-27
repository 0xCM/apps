//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVarResolver
    {
        IExpr Resolve(VarSymbol name);
    }

    public interface IVarResolver<T> : IVarResolver
        where T : IExpr
    {
        new T Resolve(VarSymbol name);

        IExpr IVarResolver.Resolve(VarSymbol name)
            => Resolve(name);
    }
}