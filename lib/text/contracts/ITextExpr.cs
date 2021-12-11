//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextExpr
    {
        string Body {get;}

        ITextVarKind VarKind {get;}

        string Eval();
    }
}