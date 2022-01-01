//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public interface IRule : IArrow
    {
    }

    public interface IRule<A,C> : IRule, IArrow<A,C>
        where A : IExpr
        where C : IExpr
    {

    }

    public interface IRule<T> : IRule<T,T>
        where T : IExpr
    {

    }
}