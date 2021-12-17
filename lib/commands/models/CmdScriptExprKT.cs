//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdScriptExpr<K,T> : ICmdScriptExpr<K,T>
        where K : unmanaged
    {
        public K Id {get;}

        public T Content {get;}

        [MethodImpl(Inline)]
        public CmdScriptExpr(T src)
        {
            Id = default;
            Content = src;
        }

        [MethodImpl(Inline)]
        public CmdScriptExpr(K id, T src)
        {
            Id = id;
            Content = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptExpr<K,T>(T src)
            => new CmdScriptExpr<K,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdScriptExpr<K,T> src)
            => src.Format();

        [MethodImpl(Inline)]
        public string Format()
            => Content?.ToString() ?? EmptyString;

        public override string ToString()
            => Format();
    }
}