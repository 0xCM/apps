//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IRule : ITextual
    {
    }

    [Free]
    public interface IRule<A,C> : IRule
        where A : IExpr
        where C : IExpr
    {

    }

    [Free]
    public interface IRule<T> : IRule<T,T>
        where T : IExpr
    {

    }
}