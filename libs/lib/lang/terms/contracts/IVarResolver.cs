//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVarResolver
    {
        IExpr Resolve(VarSymbol name);

        T Resolve<T>(VarSymbol name)
            where T : IExpr;
    }
}