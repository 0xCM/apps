//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextVar : ITextual, INullity, IVar<string>
    {
        ITextVarExpr VarExpr {get;}

        bool INullity.IsEmpty
            => text.empty(Value);
    }

    public interface ITextVar<K> : ITextVar
        where K : ITextVarExpr
    {
        new K VarExpr {get;}

        ITextVarExpr ITextVar.VarExpr
            => VarExpr;
    }
}