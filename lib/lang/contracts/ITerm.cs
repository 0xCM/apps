//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITerm : ITextual, INullity
    {
        Index<ITerm> Terms => sys.empty<ITerm>();
    }

    [Free]
    public interface ITerm<V> : ITerm, IValue<V>
    {

    }

    [Free]
    public interface ITerm<T,V> : ITerm<V>
        where T : ITerm<T,V>
    {

    }

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