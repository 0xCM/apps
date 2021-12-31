//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IVarValue : ITextual
    {
        VarSymbol Name {get;}

        string Value {get;}

        string Format(VarContextKind vck)
            => VarSymbol.format(vck, this);

        string ITextual.Format()
            => VarSymbol.format(this);
    }

    [Free]
    public interface IVarValue<T> : IVarValue
    {
        new T Value {get;}

        string IVarValue.Value
            => Value?.ToString() ?? "";
    }
}