//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextVar : INullity, ISysVar<@string>
    {
        ITextVarExpr Expr {get;}

        bool INullity.IsEmpty
            => text.empty(Value);
    }

    public interface ITextVar<K> : ITextVar
        where K : ITextVarExpr
    {
        new K Expr {get;}

        ITextVarExpr ITextVar.Expr
            => Expr;
    }
}