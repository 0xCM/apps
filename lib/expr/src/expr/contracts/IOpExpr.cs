//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IOpExpr : IExpr
    {
        Label OpName {get;}
    }

    [Free]
    public interface IOpExpr<K> : IOpExpr, IExpr<K>
        where K : unmanaged
    {

    }

    [Free]
    public interface IOpExpr<F,K> : IOpExpr<K>
        where F : IOpExpr<F,K>
        where K : unmanaged
    {

    }

    [Free]
    public interface IUnaryOpExpr<F,K,T> : IOpExpr<K>
        where F : IUnaryOpExpr<F,K,T>
        where K : unmanaged
    {
        F Make(T src);
    }

    [Free]
    public interface IBinaryOpExpr<F,K,A0,A1> : IOpExpr<K>
        where F : IBinaryOpExpr<F,K,A0,A1>
        where K : unmanaged
    {
        F Make(A0 a0, A1 a1);
    }

    [Free]
    public interface IBinaryOpExpr<F,K,T> : IBinaryOpExpr<F,K,T,T>
        where F : IBinaryOpExpr<F,K,T>
        where K : unmanaged
    {
    }

    [Free]
    public interface ITernaryOpExpr<F,K,A0,A1,A2> : IOpExpr<K>
        where F : ITernaryOpExpr<F,K,A0,A1,A2>
        where K : unmanaged
    {
        F Make(A0 a0, A1 a1, A2 a2);
    }

    public interface ITernaryOpExpr<F,K,T> : ITernaryOpExpr<F,K,T,T,T>
        where F : ITernaryOpExpr<F,K,T>
        where K : unmanaged
    {

    }
}