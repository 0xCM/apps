//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IScalarExpr : IExpr
    {
        TypeSpec ScalarType {get;}
    }

    [Free]
    public interface IScalarExpr<K> : IScalarExpr, IExpr<K>
        where K : unmanaged
    {

    }
}