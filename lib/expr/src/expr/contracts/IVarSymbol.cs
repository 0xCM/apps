//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVarSymbol
    {
        Name Name {get;}
    }

    [Free]
    public interface IVarSymbol<T> : IVarSymbol, ITypedIdentity<T>
    {
        Name IVarSymbol.Name
            => Id?.ToString() ?? string.Empty;
    }
}