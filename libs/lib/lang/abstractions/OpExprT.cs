//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    public abstract class OpExpr<F,K> : Expr<F,K>
        where F : OpExpr<F,K>
        where K : unmanaged
    {
        public abstract Identifier OpName {get;}
    }
}