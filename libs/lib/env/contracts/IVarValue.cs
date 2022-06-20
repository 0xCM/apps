//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVarValue : ITextual
    {
        VarSymbol VarName {get;}

        string VarValue {get;}

        string Format(VarContextKind vck)
            => VarSymbol.format(vck, this);

        string ITextual.Format()
            => VarSymbol.format(this);
    }

    [Free]
    public interface IVarValue<T> : IVarValue
    {
        new T VarValue {get;}

        string IVarValue.VarValue
            => VarValue?.ToString() ?? "";
    }
}