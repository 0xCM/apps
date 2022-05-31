//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Free]
    public interface IToken
    {
        ulong Kind {get;}

        ulong Value {get;}
    }

    [Free]
    public interface IToken<T> : IToken
        where T : unmanaged, IEquatable<T>
    {
        new T Kind {get;}

        new T Value {get;}

        ulong IToken.Kind
            => bw64(Kind);

        ulong IToken.Value
            => bw64(Value);
    }

    [Free]
    public interface IToken<K,V> : IToken<V>
        where K : unmanaged
        where V : unmanaged, IEquatable<V>
    {
        new K Kind {get;}

        V IToken<V>.Kind
            => @as<K,V>(Kind);
    }
}