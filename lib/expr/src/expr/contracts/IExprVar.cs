//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IExprVar : ITextual
    {
        VarSymbol Symbol {get;}

        string Value {get;}

        string Format(VarContextKind vck)
            => VarSymbol.format(vck, this);

        string ITextual.Format()
            => VarSymbol.format(this);
    }

    [Free]
    public interface IExprVar<T> : IExprVar
    {
        new T Value {get;}

        string IExprVar.Value
            => Value?.ToString() ?? "";
    }
}