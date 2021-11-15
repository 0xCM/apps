//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IExpr : ITextual
    {

    }

    [Free]
    public interface IExpr<K> : IExpr
        where K : unmanaged
    {
        K Kind {get;}
    }
}