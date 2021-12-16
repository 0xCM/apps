//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalarCmpPred<T> : IBinaryOpExpr<T>, IScalarExpr<T>
        where T : IScalarExpr
    {

    }

    [Free]
    public interface IScalarCmpPred<F,T> : IScalarCmpPred<T>, IBinaryOpExpr<F,CmpPredKind,T,T>
        where F : IScalarCmpPred<F,T>
        where T : IScalarExpr
    {

    }
}