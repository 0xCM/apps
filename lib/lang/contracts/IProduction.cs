//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProduction : IRule, IArrow<IExpr>
    {
        bool YieldsSeq => false;

    }

    public interface IProduction<S,T> : IProduction
        where S : IExpr
        where T : IExpr
    {
        new S Source {get;}

        new T Target {get;}

        IExpr IArrow<IExpr,IExpr>.Source
            => Source;

        IExpr IArrow<IExpr,IExpr>.Target
            => Target;
    }
}