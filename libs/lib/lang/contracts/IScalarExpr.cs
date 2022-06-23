//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IScalarExpr : IExpr
    {
        TypeSpec ScalarType {get;}
    }
}