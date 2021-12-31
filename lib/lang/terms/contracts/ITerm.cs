//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// The idea is to loosely follow https://en.wikipedia.org/wiki/Term_(logic)
    /// </summary>
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
}