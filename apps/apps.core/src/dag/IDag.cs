//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDag : IExpr
    {
        dynamic Left {get;}

        dynamic Right {get;}
    }

    [Free]
    public interface IDag<L,R> : IDag
        where L : IExpr
        where R : IExpr
    {
        new L Left {get;}

        new R Right {get;}

        dynamic IDag.Left
            => Left;

        dynamic IDag.Right
            => Right;
    }

    [Free]
    public interface IDag<T> : IDag<T,T>
        where T : IExpr
    {

    }
}