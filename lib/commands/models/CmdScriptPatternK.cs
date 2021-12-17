//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CmdScriptPattern<K> : ITypedIdentity<K>
        where K : unmanaged
    {
        public K Id {get;}

        public string Content {get;}

        [MethodImpl(Inline)]
        public CmdScriptPattern(string content)
        {
            Id = default;
            Content = content;
        }

        [MethodImpl(Inline)]
        public CmdScriptPattern(K id, string content)
        {
            Id = id;
            Content = content;
        }

        public override string ToString()
            => Content ?? EmptyString;

        public override int GetHashCode()
            => Content?.GetHashCode() ?? 0;

        public bool Equals(CmdScriptPattern<K> src)
            => string.Equals(Content, src.Content, NoCase);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern<K>(string src)
            => new CmdScriptPattern<K>(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdScriptPattern<K> src)
            => src.Content;

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern(CmdScriptPattern<K> src)
            => new CmdScriptPattern(src.Id.ToString(), src.Content);

        [MethodImpl(Inline)]
        public static implicit operator CmdScriptPattern<K>(Paired<K,string> src)
            => new CmdScriptPattern<K>(src.Left, src.Right);
    }
}