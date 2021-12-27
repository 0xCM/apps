//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVarSymbol : INamedTerm
    {

    }

    [Free]
    public interface IVarSymbol<T> : IVarSymbol, ITypedIdentity<T>
    {
        Name INamed.Name
            => Id?.ToString() ?? string.Empty;

        bool INullity.IsEmpty
            => Name.IsEmpty;
    }
}