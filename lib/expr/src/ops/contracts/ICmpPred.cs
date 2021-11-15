//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ICmpPred<F,T> : IBinaryOpExpr<F,CmpPredKind,T,T>
        where F : ICmpPred<F,T>
    {

    }
}