//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface INamedTerm : ITerm, INamed
    {

    }

    [Free]
    public interface INamedTerm<V> : INamedTerm, ITerm<V>
    {

    }

    public interface INamedTerm<T,V> : INamedTerm<V>, ITerm<T,V>
        where T : INamedTerm<T,V>
    {

    }
}