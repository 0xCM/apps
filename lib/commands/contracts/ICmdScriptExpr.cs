//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ICmdScriptExpr : ITextual
    {
        string Id {get;}
    }

    [Free]
    public interface ICmdScriptExpr<K,T> : ITypedIdentity<K>, IContented<T>
        where K : unmanaged
    {

    }
}