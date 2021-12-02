//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDag : ITerm
    {

    }

    [Free]
    public interface IDag<L,R> : IDag
        where L : ITerm
        where R : ITerm
    {
        L Left {get;}

        R Right {get;}
    }

    [Free]
    public interface IDag<T> : IDag<T,T>
        where T : ITerm
    {

    }
}