//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ScriptExpr<K,T> : ICmdScriptExpr<K,T>
        where K : unmanaged
    {
        public K Id {get;}

        public T Content {get;}

        [MethodImpl(Inline)]
        public ScriptExpr(T src)
        {
            Id = default;
            Content = src;
        }

        [MethodImpl(Inline)]
        public ScriptExpr(K id, T src)
        {
            Id = id;
            Content = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator ScriptExpr<K,T>(T src)
            => new ScriptExpr<K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator string(ScriptExpr<K,T> src)
            => src.Format();

        [MethodImpl(Inline)]
        public string Format()
            => Content?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();
    }
}