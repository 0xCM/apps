//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDag : IExpr2
    {
        IExpr2 Left {get;}

        IExpr2 Right {get;}
    }

    [Free]
    public interface IDag<L,R> : IDag
        where L : IExpr2
        where R : IExpr2
    {
        new L Left {get;}

        new R Right {get;}

        IExpr2 IDag.Left
            => Left;

        IExpr2 IDag.Right
            => Right;
    }

    [Free]
    public interface IDag<T> : IDag<T,T>
        where T : IExpr2
    {

    }
}