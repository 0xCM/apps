//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IUnaryBitLogicOp<F,T> : IUnaryOpExpr<F,UnaryBitLogicKind,T>
        where F : IUnaryBitLogicOp<F,T>
    {

    }    
}