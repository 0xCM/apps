//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IExprEvaluator
    {
        dynamic Evaluate(IExpr src);
    }

    [Free]
    public interface IExprEvaluator<T> : IExprEvaluator
    {
        new T Evaluate(IExpr src);

        dynamic IExprEvaluator.Evaluate(IExpr src)
            => Evaluate(src);
    }

    [Free]
    public interface IExprEvaluator<S,T>
        where S : IExpr
    {
        T Evaluate(S src);
    }
}